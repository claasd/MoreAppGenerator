using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Caffoa;
using Microsoft.AspNetCore.Http;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class FormBuilder : FormContainer<IFormBuilder>, IFormBuilder
{
    private static string? _formUserRoleId = null;
    private readonly RestClient _client;
    private readonly string _name;
    private string _label;
    private readonly IFolder? _folder;
    private string? _desc;
    private readonly List<string> _tags = new();
    private readonly HashSet<string> _groupIds = new();
    private string _icon = "ios-paper-outline";
    private string? _inAppDesc = null;
    private int? _folderPosition;

    public FormBuilder(RestClient client, string name, string label, IFolder? folder = null)
    {
        _client = client;
        _name = name;
        _label = label;
        _folder = folder;
    }


    private FormDto FormUpdate(string hash, FormVersionDto? formVersion = null)
    {
        return new FormDto
        {
            PublishedVersion = formVersion is null
                ? null
                : new FormPublishedVersionDto()
                {
                    FormVersion = formVersion.Id,
                    PublishedBy = formVersion.Meta.LastUpdatedBy,
                    PublishedDate = DateTimeOffset.UtcNow
                },
            Meta = new FormMetadataDto()
            {
                Name = _label,
                Tags = new[] { GeneratorTag, $"{GeneratorHashPrefix}{hash}" }.Concat(_tags).ToArray(),
                Icon = _icon,
                IconColor = FormMetadataDto.IconColorValue.Default,
                Description = _desc
            }
        };
    }

    private string GeneratorPrefix => $"generatorId:";
    private string GeneratorTag => $"{GeneratorPrefix}{_name}";
    private const string GeneratorHashPrefix = "generatorHash:";

    public IFormBuilder Tag(string tag)
    {
        _tags.Add(tag);
        return this;
    }

    public IFormBuilder Icon(string icon)
    {
        _icon = icon;
        return this;
    }

    public IFormBuilder InAppDescription(string inAppDesc)
    {
        _inAppDesc = inAppDesc;
        return this;
    }

    public IFormBuilder Name(string name)
    {
        _label = name;
        return this;
    }

    public async Task<IFormInfo> BuildAsync(bool removeDrafts = true)
    {
        var formClient = new MoreAppFormsClient(_client.HttpClient);
        var allForms = await formClient.Find1Async(_client.CustomerId, null);
        var form = allForms.FirstOrDefault(form => form.Meta.Tags.Contains(GeneratorTag));
        if (form is null)
            form = await formClient.CreateForm1Async(_client.CustomerId, FormUpdate("0"));
        var hash = GetHash();
        var currentHash = form.Meta?.Tags?.FirstOrDefault(tag => tag.StartsWith(GeneratorHashPrefix))?.Split(":")[1];
        if (hash != currentHash)
        {
            if (_folder != null)
            {
                var folderClient = new MoreAppFoldersClient(_client.HttpClient);
                await folderClient.MoveFormAsync(_client.CustomerId, _folder.Uid, form.Id);
                if (_folderPosition != null)
                    await folderClient.MovePositionFormAsync(_client.CustomerId, _folder.Uid, form.Id, _folderPosition.Value);
            }

            FormVersionDto newVersion;
            try
            {
                newVersion = await UpdateForm(form.Id);
            }
            catch (Exception) when (removeDrafts)
            {
                await RemoveVersionDrafts(form.Id);
                newVersion = await UpdateForm(form.Id);
            }

            form = await formClient.PatchForm1Async(_client.CustomerId, form.Id, FormUpdate(hash, newVersion));
            await AddFormToGroups(form.Id);
        }

        return new FormInfo(form.Id, _name, _label, form.Meta?.Tags);
    }

    public string GetHash()
    {
        Elements.ForEach(e => e.Consolidate());
        var hashBaseElements = Elements.Select(e => e.HashValue()).ToList();
        hashBaseElements.Add(_label);
        if (_desc != null)
            hashBaseElements.Add(_desc);
        if (_tags.Any())
            hashBaseElements.Add(string.Join("|", _tags));
        hashBaseElements.Add(_icon);
        if (_inAppDesc != null)
            hashBaseElements.Add(_inAppDesc);
        if (_folderPosition != null)
            hashBaseElements.Add(_folderPosition.Value.ToString());
        if (_folder != null)
            hashBaseElements.Add(_folder.Uid);
        if(_groupIds.Count > 0)
            hashBaseElements.Add(Hash(_groupIds.OrderBy(i=>i).ToArray()));
        return Hash(hashBaseElements.ToArray());
    }

    public string CreateOpenApiSpec()
    {
        var builder = new OpenApiBuilder();
        builder.Add(Elements, _name);
        return builder.GenerateSpec();
    }

    private async ValueTask AddFormToGroups(string formId)
    {
        if (_groupIds.Count == 0)
            return;
        if (_formUserRoleId is null)
        {
            var rolesClient = new MoreAppRolesClient(_client.HttpClient);
            var roles = await rolesClient.GetRolesAsync(_client.CustomerId);
            _formUserRoleId = roles.First(r => r.TranslatableKey == "ROLE_FORM_USER").Id;
        }

        var groupClient = new MoreAppGroupsClient(_client.HttpClient);
        var groups = await groupClient.GetGroupsAsync(_client.CustomerId);
        foreach (var groupId in _groupIds)
        {
            var existing = groups.FirstOrDefault(g => g.Id == groupId)?.Grants.FirstOrDefault(g => g.ResourceId == formId && g.RoleId == _formUserRoleId);
            if (existing != null)
                continue;
            await groupClient.PatchGrant2Async(_client.CustomerId, groupId, new RestGrantChange()
            {
                Operation = RestGrantChange.OperationValue.ADD,
                ResourceId = formId,
                ResourceType = RestGrantChange.ResourceTypeValue.FORM,
                RoleId = _formUserRoleId
            });
        }
    }

    private async Task<FormVersionDto> UpdateForm(string formId)
    {
        var versionClient = new MoreAppFormVersionsClient(_client.HttpClient);
        var data = new FormVersionDto()
        {
            FormId = formId,
            Fields = Elements.Select(e => e.Field).ToList(),
            Rules = Elements.SelectMany(e => e.Rules.Select(rule => (rule, e.Field.Uid))).Select((item, index) => item.rule.ToRule(item.Uid, $"#{index}")).ToList(),
            Dependencies = ArraySegment<Dependency>.Empty,
            Integrations = ArraySegment<IntegrationConfiguration>.Empty,
            Triggers = ArraySegment<Trigger>.Empty,
            Settings = new Settings()
            {
                Interaction = Settings.InteractionValue.IMMEDIATE_UPLOAD,
                SaveMode = Settings.SaveModeValue.SAVE_AND_CLOSE_ONLY,
                ItemHtml = _inAppDesc,
                SearchSettings = new SearchSettings()
                {
                    Enabled = false,
                    FilteringEnabled = false
                }
            }
        };
        
        var formVersion = await versionClient.CreateFormVersion1Async(_client.CustomerId, formId, data);
        try
        {
            return await versionClient.FinalizeFormVersion1Async(_client.CustomerId, formId, formVersion.Id);
        }
        catch(Exception)
        {
            // try to delete the newly created version if it could not be finalized, but ignore errors
            try
            {
                await versionClient.DeleteFormVersion1Async(_client.CustomerId, formId, formVersion.Id);
            } catch (Exception)
            {
                // ignored
            }
            throw;
        }

    }

    private async Task RemoveVersionDrafts(string formId)
    {
        var versionClient = new MoreAppFormVersionsClient(_client.HttpClient);
        var versions = new List<FormVersionDto>();
        for (var page = 0; page < 999; page++)
        {
            var versionPage = await versionClient.GetFormVersionsForForm1Async(_client.CustomerId, formId, page, 50);
            if (versionPage.Count == 0)
                break;
            versions.AddRange(versionPage.Where(v => v.Meta.Status != FormVersionMetadata.StatusValue.FINAL));
        }

        foreach (var version in versions)
        {
            await versionClient.DeleteFormVersion1Async(_client.CustomerId, formId, version.Id);
        }
    }

    public IFormBuilder Description(string desc)
    {
        _desc = desc;
        return this;
    }

    public IFormBuilder AddToGroup(IGroup group)
    {
        _groupIds.Add(group.Id);
        return this;
    }

    public IFormBuilder FolderPosition(int position)
    {
        _folderPosition = position;
        return this;
    }

    public static async Task<IFormInfo?> ExistingFormById(RestClient client, string id)
    {
        var formClient = new MoreAppFormsClient(client.HttpClient);
        try
        {
            var form = await formClient.GetFormByCustomerId1Async(client.CustomerId, id);
            var name = form.Meta.Tags.FirstOrDefault(tag => tag.StartsWith("generatorId:"))?.Split(":")[1] ?? "unknown";
            return new FormInfo(form.Id, name, form.Meta.Name, form.Meta.Tags);
        }
        catch (CaffoaWebClientException e) when (e.StatusCode == 404)
        {
            return null;
        }
    }

    public static async Task<IFormInfo?> ExistingFormByName(RestClient client, string name)
    {
        var formClient = new MoreAppFormsClient(client.HttpClient);
        var allForms = await formClient.Find1Async(client.CustomerId, null);
        var form = allForms.FirstOrDefault(form => form.Meta.Tags.Contains($"generatorId:{name}"));
        if (form is null)
            return null;
        return new FormInfo(form.Id, name, form.Meta.Name, form.Meta.Tags);
    }

    public static async Task<MoreAppReadInfo> ReadAsync(RestClient client, string nameOrId, string versionId, bool useLangFile, string lang)
    {
        var formClient = new MoreAppFormsClient(client.HttpClient);
        var allForms = await formClient.Find1Async(client.CustomerId, null);
        var form = allForms.FirstOrDefault(form => form.Meta.Tags.Contains($"generatorId:{nameOrId}") || form.Id == nameOrId);
        if (form is null)
            throw new InvalidOperationException($"Form {nameOrId} not found");
        var versionClient = new MoreAppFormVersionsClient(client.HttpClient);
        var versions = await versionClient.GetFormVersionsForForm1Async(client.CustomerId, form.Id, null, 100);
        var version = versions.FirstOrDefault(v => v.Id == versionId);
        if (version is null && !string.IsNullOrEmpty(versionId))
            throw new InvalidOperationException($"Version {versionId} not found");
        version ??= versions.FirstOrDefault(v => v.Id == form.PublishedVersion.FormVersion);
        if (version is null)
            throw new InvalidOperationException($"No active version found");
        return new ReverseReader(form, version).Read(useLangFile, lang);
    }
}

internal class FormInfo : IFormInfo
{
    public FormInfo(string id, string name, string label, ICollection<string>? tags)
    {
        Id = id;
        Name = name;
        Label = label;
        Tags = tags?.ToList() ?? [];
    }

    public string Id { get; }
    public string Name { get; }
    public string Label { get; }
    public IReadOnlyCollection<string> Tags { get; }
}