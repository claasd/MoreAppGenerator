using CdIts.CosmosExtensions;
using Microsoft.Azure.Cosmos;
using MoreAppBuilder.Cache.Model;
using MoreAppBuilder.Implementation;

namespace MoreAppBuilder.Cache;

public class MoreAppCosmosCache(Container container) : IMoreAppCaching
{
    public TimeSpan CacheDuration { get; set; } = TimeSpan.FromDays(14);

    public async ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash) =>
        await container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
                c.CustomerId == customerId && c.FormName == name && c.Hash == hash)
            .Where(c => c.Type == CosmosFormCache.CacheType.Form)
            .Select(c => c.ElementId)
            .FirstOrDefaultItemAsync();

    public async ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash) =>
        await container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
                c.CustomerId == customerId && c.FormName == name && c.Hash == hash)
            .Where(c => c.Type == CosmosFormCache.CacheType.Folder)
            .Select(c => c.ElementId)
            .FirstOrDefaultItemAsync();

    public ValueTask<IDataSource?> FindDataSourceByHashAsync(int customerId, string name, string hash)
        => FindDataSourceIntAsync(customerId, name, hash);

    public async ValueTask<IDataSource?> FindDataSourceIntAsync(int customerId, string name, string? hash = null)
    {
        var query = container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
            c.CustomerId == customerId && c.FormName == name && c.Type == CosmosFormCache.CacheType.DataSource);
        if (hash != null)
            query = query.Where(c => c.Hash == hash);

        var result = await query.OrderByDescending(c=>c.Timestamp).Select(c => new
            {
                Id = c.ElementId,
                Columns = c.Columns,
            })
            .FirstOrDefaultItemAsync();
        return result == null ? null : new DataSource(result.Id, name, result.Columns);
    }

    public ValueTask<IDataSource?> FindLatestDataSourceAsync(int customerId, string name)
        => FindDataSourceIntAsync(customerId, name);

    public async ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id) =>
        await container.CreateItemAsync(new CosmosFormCache
        {
            CustomerId = customerId,
            FormName = name,
            Hash = hash,
            ElementId = id,
            Type = CosmosFormCache.CacheType.Form,
            TimeToLive = (int)CacheDuration.TotalSeconds,
            Timestamp = DateTimeOffset.UtcNow
        });

    public async ValueTask StoreFolderIdAsync(int customerId, string name, string hash, string id) =>
        await container.CreateItemAsync(new CosmosFormCache
        {
            CustomerId = customerId,
            FormName = name,
            Hash = hash,
            ElementId = id,
            Type = CosmosFormCache.CacheType.Folder,
            TimeToLive = (int)CacheDuration.TotalSeconds,
            Timestamp = DateTimeOffset.UtcNow
        });

    public async ValueTask StoreDataSourceAsync(int customerId, string hash, IDataSource dataSource)
    {
        await container.CreateItemAsync(new CosmosFormCache
        {
            CustomerId = customerId,
            FormName = dataSource.Name,
            Hash = hash,
            ElementId = dataSource.Id,
            Columns = dataSource.Columns?.ToList() ?? [],
            Type = CosmosFormCache.CacheType.DataSource,
            TimeToLive = (int)CacheDuration.TotalSeconds,
            Timestamp = DateTimeOffset.UtcNow
        });
    }
}