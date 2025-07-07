using CdIts.CosmosExtensions;
using Microsoft.Azure.Cosmos;
using MoreAppBuilder.Cache.Model;

namespace MoreAppBuilder.Cache;

public class MoreAppCosmosCache(Container container) : IMoreAppCaching
{
    public TimeSpan CacheDuration { get; set; } = TimeSpan.FromDays(14);
    public async ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash) =>
        await container.GetItemLinqQueryable<CosmosFormCache>().Where(c=>
                c.CustomerId == customerId && c.FormName == name && c.Hash == hash)
            .Where(c=> c.Type == CosmosFormCache.CacheType.Form)
            .Select(c => c.ElementId)
            .FirstOrDefaultItemAsync();

    public async ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash) =>
        await container.GetItemLinqQueryable<CosmosFormCache>().Where(c=>
                c.CustomerId == customerId && c.FormName == name && c.Hash == hash)
            .Where(c=> c.Type == CosmosFormCache.CacheType.Folder)
            .Select(c => c.ElementId)
            .FirstOrDefaultItemAsync();

    public async ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id) =>
        await container.CreateItemAsync(new CosmosFormCache
        {
            CustomerId = customerId,
            FormName = name,
            Hash = hash,
            ElementId = id,
            Type = CosmosFormCache.CacheType.Form,
            TimeToLive = (int)CacheDuration.TotalSeconds
        });

    public Task StoreFolderIdAsync(int customerId, string name, string hash, string id) =>
        container.CreateItemAsync(new CosmosFormCache
        {
            CustomerId = customerId,
            FormName = name,
            Hash = hash,
            ElementId = id,
            Type = CosmosFormCache.CacheType.Folder,
            TimeToLive = (int)CacheDuration.TotalSeconds
        });
}