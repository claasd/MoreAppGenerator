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
    private static string? FormUserRoleId = null;
    private readonly RestClient _client;
    private readonly string _name;
    private readonly string _label;
    private readonly IFolder? _folder;
    private string? _desc;
    private readonly List<string> _tags = new();
    private HashSet<string> _groupIds = new();
    private string _icon = "ios-paper-outline";
    
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
            PublishedVersion = formVersion is null ? null : new FormPublishedVersionDto()
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

    public async Task<IFormInfo> BuildAsync()
    {
        var formClient = new MoreAppFormsClient(_client.HttpClient);
        var allForms = await formClient.Find1Async(_client.CustomerId, null);
        var form = allForms.FirstOrDefault(form => form.Meta.Tags.Contains(GeneratorTag));
        if (form is null)
            form = await formClient.CreateForm1Async(_client.CustomerId, FormUpdate("0"));
        if (_folder != null)
        {
            var folderClient = new MoreAppFoldersClient(_client.HttpClient);
            await folderClient.MoveFormAsync(_client.CustomerId, _folder.Uid, form.Id);
        }
        Elements.ForEach(e=>e.Consolidate());
        var hashBaseElements = Elements.Select(e => e.HashValue()).ToList();
        hashBaseElements.Add(_label);
        if(_desc != null)
            hashBaseElements.Add(_desc);
        if(_tags.Any())
            hashBaseElements.Add(string.Join("|",_tags));
        hashBaseElements.Add(_icon);
        var hash = Hash(hashBaseElements.ToArray());
        var currentHash = form.Meta?.Tags?.FirstOrDefault(tag => tag.StartsWith(GeneratorHashPrefix))?.Split(":")[1];
        if (hash != currentHash)
        {
            var newVersion = await UpdateForm(form.Id);
            form = await formClient.PatchForm1Async(_client.CustomerId, form.Id, FormUpdate(hash, newVersion));
        }

        await AddFormToGroups(form.Id);
        return new FormInfo(form.Id, _name, _label, form.Meta?.Tags);
    }

    private async ValueTask AddFormToGroups(string formId)
    {
        if(_groupIds.Count == 0)
            return;
        if (FormUserRoleId is null)
        {
            var rolesClient = new MoreAppRolesClient(_client.HttpClient);
            var roles = await rolesClient.GetRolesAsync(_client.CustomerId);
            FormUserRoleId = roles.First(r => r.TranslatableKey == "ROLE_FORM_USER").Id;
        }
        var groupClient = new MoreAppGroupsClient(_client.HttpClient);
        var groups = await groupClient.GetGroupsAsync(_client.CustomerId);
        foreach (var groupId in _groupIds)
        {
            var existing = groups.FirstOrDefault(g => g.Id == groupId)?.Grants.FirstOrDefault(g=>g.ResourceId == formId && g.RoleId == FormUserRoleId);
            if(existing != null)
                continue;
            await groupClient.PatchGrant2Async(_client.CustomerId, groupId, new RestGrantChange()
            {
                Operation = RestGrantChange.OperationValue.ADD,
                ResourceId = formId,
                ResourceType = RestGrantChange.ResourceTypeValue.FORM,
                RoleId = FormUserRoleId
            });
        }
        
    }

    private async Task<FormVersionDto> UpdateForm(string formId)
    {
        var versionClient = new MoreAppFormVersionsClient(_client.HttpClient);
        var versions = await versionClient.GetFormVersionsForForm1Async(_client.CustomerId, formId, null, 10);
        var version = versions.FirstOrDefault(v=>v.Meta.Status != FormVersionMetadata.StatusValue.FINAL);
        var data = new FormVersionDto()
        {
            FormId = formId,
            Fields = Elements.Select(e => e.Field).ToList(),
            Rules = Elements.SelectMany(e => e.Rules.Select(rule=>(rule,e.Field.Uid))).Select((item, index) => item.rule.ToRule(item.Uid, $"#{index}")).ToList(),
            Dependencies = ArraySegment<Dependency>.Empty,
            Integrations = ArraySegment<IntegrationConfiguration>.Empty,
            Triggers = ArraySegment<Trigger>.Empty,
            Settings = new Settings()
            {
                Interaction = Settings.InteractionValue.IMMEDIATE_UPLOAD,
                SaveMode = Settings.SaveModeValue.SAVE_AND_CLOSE_ONLY,
                SearchSettings = new SearchSettings()
                {
                    Enabled = false,
                    FilteringEnabled = false
                }
            }
        };
        
        var formVersion = version is null
            ? await versionClient.CreateFormVersion1Async(_client.CustomerId, formId, data)
            : await versionClient.UpdateFormVersion1Async(_client.CustomerId, formId, version.Id, data);
        return await versionClient.FinalizeFormVersion1Async(_client.CustomerId, formId, formVersion.Id);
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