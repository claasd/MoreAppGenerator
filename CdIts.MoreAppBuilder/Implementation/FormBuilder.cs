using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using Caffoa;
using Microsoft.AspNetCore.Http;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class FormBuilder : FormContainer<IFormBuilder>, IFormBuilder
{
    private readonly RestClient _client;
    private readonly string _name;
    private readonly string _label;
    private readonly IFolder? _folder;
    private string? _desc;
    private readonly List<string> _tags = new();

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
                Icon = "ios-paper-outline",
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

    public async Task<IFormInfo> BuildAsync()
    {
        var formClient = new MoreAppFormsClient(_client.HttpClient);
        var versionClient = new MoreAppFormVersionsClient(_client.HttpClient);
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
        
        var hash = Hash(hashBaseElements.ToArray());
        var currentHash = form.Meta?.Tags?.FirstOrDefault(tag => tag.StartsWith(GeneratorHashPrefix))?.Split(":")[1];
        if(hash == currentHash)
            return new FormInfo(form.Id, _name, _label, form.Meta?.Tags);
        var versions = await versionClient.GetFormVersionsForForm1Async(_client.CustomerId, form.Id, null, 10);
        var version = versions.FirstOrDefault(v=>v.Meta.Status != FormVersionMetadata.StatusValue.FINAL);
        var data = new FormVersionDto()
        {
            FormId = form.Id,
            Fields = Elements.Select(e => e.Field).ToList(),
            Rules = Elements.Where(e=>e.Rule != null).Select((e, index)=>e.Rule!.ToRule(e.Field.Uid, $"#{index}")).ToList(),
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
                ? await versionClient.CreateFormVersion1Async(_client.CustomerId, form.Id, data)
                : await versionClient.UpdateFormVersion1Async(_client.CustomerId, form.Id, version.Id, data);
        formVersion = await versionClient.FinalizeFormVersion1Async(_client.CustomerId, form.Id, formVersion.Id);
        await formClient.PatchForm1Async(_client.CustomerId, form.Id, FormUpdate(hash, formVersion));
        return new FormInfo(form.Id, _name, _label, form.Meta?.Tags);
    }

    public IFormBuilder Description(string desc)
    {
        _desc = desc;
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