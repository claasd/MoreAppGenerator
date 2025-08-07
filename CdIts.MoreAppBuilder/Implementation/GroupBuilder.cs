using Microsoft.Extensions.Logging;
using MoreAppBuilder.Implementation.Client;
using MoreAppBuilder.Implementation.Model.Core;

namespace MoreAppBuilder.Implementation;

internal class GroupBuilder(RestClient client, IMoreAppCaching caching, string name, string? groupIdHint = null)
    : IGroupBuilder
{
    public Task<IGroup> BuildAsync(bool allowUseCache = true) => ReadOrBuildAsync(allowUseCache, true);
    private async Task<IGroup> ReadOrBuildAsync(bool allowUseCache, bool allowCreation)
    {
        var logger = MoreAppService.Logger;
        logger.LogInformation("Building group with name {Name}", name);
        if (allowUseCache)
        {
            var cachedId = await caching.FindGroupIdAsync(client.CustomerId, name);
            if (cachedId is not null)
            {
                logger.LogInformation("Found cached group with name {Name} and id {Id}", name, cachedId);
                return new GroupInfo( cachedId, name);
            }
        }

        var groupClient = new MoreAppGroupsClient(client.HttpClient);
        var groups = await groupClient.GetGroupsAsync(client.CustomerId);
        Group? group = null;
        if (groupIdHint is not null)
        {
            group = groups.FirstOrDefault(g => g.Id.Equals(groupIdHint, StringComparison.InvariantCulture));
        }

        group ??= groups.FirstOrDefault(g => g.Name.Equals(name, StringComparison.InvariantCulture));
        if(group is null && !allowCreation)
        {
            throw new InvalidOperationException($"Group with name {name} not found.");
        }
        else if (group is null)
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

        await caching.StoreGroupIdAsync(client.CustomerId, name, group.Id);
        return new GroupInfo(group.Id, group.Name);
    }

    public static async Task<IGroup> LoadAsync(RestClient restClient, string groupName, IMoreAppCaching moreAppCaching, bool allowUseCache)
    {
        var builder = new GroupBuilder(restClient, moreAppCaching, groupName);
        return await builder.ReadOrBuildAsync(allowUseCache, false);
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