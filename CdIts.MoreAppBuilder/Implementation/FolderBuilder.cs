using Caffoa;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class FolderBuilder : IFolderBuilder
{
    protected readonly RestClient Client;
    protected readonly IMoreAppCaching Caching;
    private readonly FolderMetadataDto _metadata;
    private FolderDto.StatusValue _status = FolderDto.StatusValue.ACTIVE;
    private readonly string _id;

    public string Name
    {
        get => _metadata.Name;
        set => _metadata.Name = value;
    }

    internal FolderBuilder(RestClient client, IMoreAppCaching caching, string id, string name)
    {
        _id = id;
        Client = client;
        Caching = caching;
        _metadata = new FolderMetadataDto()
        {
            Description = GeneratorId,
            Name = name
        };
    }

    public IFolderBuilder Icon(string icon)
    {
        _metadata.Icon = icon;
        return this;
    }

    public IFolderBuilder Description(string description)
    {
        _metadata.Description = $"{description}\n - {GeneratorId}";
        return this;
    }

    protected string GeneratorId => $"generatorId:{_id}";

    public IFolderBuilder HideInApp()
    {
        _status = FolderDto.StatusValue.HIDDEN;
        return this;
    }

    public async Task<IFolder> BuildAsync()
    {
        var hash = GetHash();
        var cached = await Caching.FindFolderIdByHashAsync(Client.CustomerId, _id, hash);
        if (cached != null)
        {
            return new Folder(Client, Caching, _id, cached, _metadata.Name);
        }
        var folderClient = new MoreAppFoldersClient(Client.HttpClient);
        var folders = await folderClient.GetFoldersByCustomerIdAsync(Client.CustomerId);
        var folder =
            folders.FirstOrDefault(f => f.Meta?.Description != null && f.Meta.Description.Contains(GeneratorId));
        if (folder is null)
        {
            folder = await folderClient.CreateFolderAsync(Client.CustomerId, new FolderDto()
            {
                Meta = _metadata,
                Status = _status
            });
        }
        else if (!folder.Meta.Equals(_metadata) || _status != folder.Status)
        {
            var patch = new JsonPatch();
            patch.AddReplace("/meta/name", _metadata.Name);
            patch.AddReplace("/meta/description", _metadata.Description);
            if (_metadata.Icon != null)
                patch.AddReplace("/meta/icon", _metadata.Icon);
            patch.AddReplace("/status", _status.Value());
            var data = JsonConvert.SerializeObject(patch);
            folder = await folderClient.UpdateFolderAsync(Client.CustomerId, folder.Id, patch);
        }

        await Caching.StoreFolderIdAsync(Client.CustomerId, _id, hash, folder.Id);
        return new Folder(Client, Caching, _id, folder.Id, folder.Meta.Name);
    }

    private string GetHash()
    {
        var data = JsonConvert.SerializeObject(_metadata);
        return Element.Hash(data, _status.Value());
    }
}

internal class MultiLangFolderBuilder : FolderBuilder, IMultiLangFolderBuilder
{
    private readonly MoreAppLanguageInstance _languageData;

    internal MultiLangFolderBuilder(RestClient client, IMoreAppCaching caching, MoreAppLanguageInstance languageData,
        string id, string langFileSectionId)
        : base(client, caching, id, languageData.FolderName(langFileSectionId))
    {
        _languageData = languageData;
        try
        {
            Description(languageData.FolderDesc(langFileSectionId));
        }
        catch (KeyNotFoundException)
        {
            /* okay */
        }
    }

    public new IMultiLangFolderBuilder Icon(string icon)
    {
        base.Icon(icon);
        return this;
    }

    public new IMultiLangFolderBuilder Description(string description)
    {
        base.Description(description);
        return this;
    }

    public new IMultiLangFolderBuilder HideInApp()
    {
        base.HideInApp();
        return this;
    }

    public new async Task<IMultiLangFolder> BuildAsync()
    {
        var folder = await base.BuildAsync();
        return new MultiLangFolder(Client, Caching, _languageData, folder.Id, folder.Uid, folder.Name);
    }
}