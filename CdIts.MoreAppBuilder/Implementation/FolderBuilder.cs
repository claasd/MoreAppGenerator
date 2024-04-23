using Caffoa;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class FolderBuilder : IFolderBuilder
{
    private readonly RestClient _client;
    private readonly FolderMetadataDto _metadata;
    private FolderDto.StatusValue _status = FolderDto.StatusValue.ACTIVE;
    private readonly string _id;

    internal FolderBuilder(RestClient client, string id, string name)
    {
        _id = id;
        _client = client;
        _metadata = new FolderMetadataDto()
        {
            Description = $"generatorId:{id}",
            Name = name
        };
    }

    public IFolderBuilder Icon(string icon)
    {
        _metadata.Icon = icon;
        return this;
    }

    public IFolderBuilder HideInApp()
    {
        _status = FolderDto.StatusValue.HIDDEN;
        return this;
    }

    public async Task<IFolder> BuildAsync()
    {
        var folderClient = new MoreAppFoldersClient(_client.HttpClient);
        var folders = await folderClient.GetFoldersByCustomerIdAsync(_client.CustomerId);
        var folder = folders.FirstOrDefault(f => f.Meta?.Description != null && f.Meta.Description.Contains(_metadata.Description));
        if (folder is null)
        {
            folder = await folderClient.CreateFolderAsync(_client.CustomerId, new FolderDto()
            {
                Meta = _metadata,
                Status = _status
            });
        } else if (!folder.Meta.Equals(_metadata) || _status != folder.Status)
        {
            var patch = new JsonPatch();
            patch.AddReplace("/meta/name", _metadata.Name);
            patch.AddReplace("/meta/description", _metadata.Description);
            if(_metadata.Icon != null)
                patch.AddReplace("/meta/icon", _metadata.Icon);
            patch.AddReplace("/status", _status.Value());
            var data = JsonConvert.SerializeObject(patch);
            folder = await folderClient.UpdateFolderAsync(_client.CustomerId, folder.Id, patch);
        }

        return new Folder(_client, _id, folder.Id, folder.Meta.Name);
    }
}