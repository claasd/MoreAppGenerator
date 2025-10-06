using Microsoft.Extensions.Logging;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;

namespace MoreAppBuilder.Implementation;

internal class GroupBuilder(RestClient client, IMoreAppCaching caching, string name, string? groupIdHint = null)
    : IGroupBuilder
{
    public Task<IGroup> BuildAsync(bool allowUseCache = true) => ReadOrBuildAsync(allowUseCache, true);

    private async Task<IGroup> ReadOrBuildAsync(bool allowUseCache, bool allowCreation, bool useIdOnly = false)
    {
        var logger = MoreAppService.Logger;
        logger.LogInformation("Building group with name {Name}", name);
        if (allowUseCache && !useIdOnly)
        {
            var cachedId = await caching.FindGroupIdAsync(client.CustomerId, name);
            if (cachedId is not null)
            {
                logger.LogInformation("Found cached group with name {Name} and id {Id}", name, cachedId);
                return new GroupInfo(cachedId, name, false);
            }
        }

        if (allowUseCache && groupIdHint is not null)
        {
            var cachedName = await caching.FindGroupNameAsync(client.CustomerId, groupIdHint);
            if (cachedName is not null)
            {
                logger.LogInformation("Found cached group with name {Name} and id {Id}", cachedName, groupIdHint);
                return new GroupInfo(groupIdHint, cachedName, false);
            }
        }

        var groupClient = new MoreAppGroupsClient(client.HttpClient);
        var groups = await groupClient.GetGroupsAsync(client.CustomerId);
        Group? group = null;
        if (groupIdHint is not null)
        {
            group = groups.FirstOrDefault(g => g.Id.Equals(groupIdHint, StringComparison.InvariantCulture));
        }
        if(!useIdOnly)
        {
            group ??= groups.FirstOrDefault(g => g.Name.Equals(name, StringComparison.InvariantCulture));
        }
        group ??= groups.FirstOrDefault(g => g.Name.Equals(name, StringComparison.InvariantCulture));
        if (group is null && !allowCreation)
        {
            throw new InvalidOperationException($"Group with name {name} not found.");
        }

        if (group is null)
        {
            logger.LogInformation("Creating new group with name {Name}", name);
            group = await groupClient.CreateGroupAsync(client.CustomerId, new CreateGroupRequest()
            {
                Name = name
            });
        }
        else if (allowCreation && group.Name != name)
        {
            logger.LogInformation("Updating existing group with id {Id} to new name {Name}", group.Id, name);
            group.Name = name;
            group = await groupClient.PatchGroupAsync(client.CustomerId, group.Id, group);
        }
        else
        {
            logger.LogInformation("Using existing group with id {Id} and name {Name}", group.Id, group.Name);
        }
        if(group.ExternallyManaged != true) // only store if not externally managed
            await caching.StoreGroupIdAsync(client.CustomerId, name, group.Id);
        return new GroupInfo(group.Id, group.Name, group.ExternallyManaged is true);
    }

    public static async Task<IGroup> LoadAsync(RestClient restClient, string groupName, IMoreAppCaching caching,
        bool allowUseCache)
    {
        var builder = new GroupBuilder(restClient, caching, groupName);
        return await builder.ReadOrBuildAsync(allowUseCache, false);
    }


    public static async Task<IGroup> LoadByIdAsync(RestClient restClient, string id, IMoreAppCaching caching,
        bool allowUseCache)
    {
        var builder = new GroupBuilder(restClient, caching, "", id);
        return await builder.ReadOrBuildAsync(allowUseCache, false, true);
    }
}

internal class GroupInfo : IGroup
{
    public string Id { get; }
    public string Name { get; }
    public bool ExternallyManaged { get; }

    internal GroupInfo(string id, string name, bool externallyManaged)
    {
        Id = id;
        Name = name;
        ExternallyManaged = externallyManaged;
    }
}