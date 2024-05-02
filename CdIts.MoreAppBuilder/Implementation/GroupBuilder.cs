using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;

namespace MoreAppBuilder.Implementation;

internal class GroupBuilder : IGroupBuilder
{
    private readonly RestClient _client;
    private readonly string _name;
    private readonly string? _groupIdHint;

    internal GroupBuilder(RestClient client, string name, string? groupIdHint = null)
    {
        _client = client;
        _name = name;
        _groupIdHint = groupIdHint;
    }

    public async Task<IGroup> BuildAsync()
    {
        var groupClient = new MoreAppGroupsClient(_client.HttpClient);
        var groups = await groupClient.GetGroupsAsync(_client.CustomerId);
        Group? group = null;
        if(_groupIdHint is not null)
        {
            group = groups.FirstOrDefault(g => g.Id.Equals(_groupIdHint, StringComparison.InvariantCulture));
        }
        group ??= groups.FirstOrDefault(g => g.Name.Equals(_name, StringComparison.InvariantCulture));
        if(group is null)
            group = await groupClient.CreateGroupAsync(_client.CustomerId, new CreateGroupRequest()
            {
                Name = _name
            });
        else if (group.Name != _name)
        {
            group.Name = _name;
            group = await groupClient.PatchGroupAsync(_client.CustomerId, group.Id, group);
        }
        return new GroupInfo(group.Id, group.Name);
    }
}

internal class GroupInfo : IGroup
{
    public string Id { get; }
    public string Name { get; }

    internal GroupInfo(string id, string name)
    {
        Id = id;
        Name = name;
    }
}