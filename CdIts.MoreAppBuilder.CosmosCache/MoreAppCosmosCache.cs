using CdIts.CosmosExtensions;
using Microsoft.Azure.Cosmos;
using MoreAppBuilder.Cache.Model;
using MoreAppBuilder.Implementation;

namespace MoreAppBuilder.Cache;

public class MoreAppCosmosCache(Container container, bool cacheLatestOnly = false, bool returnCacheOnMismatch = false) : IMoreAppCaching
{
    public TimeSpan CacheDuration { get; set; } = TimeSpan.FromDays(14);
    public List<string> IgnoreFormPrefixes { get; } = [];
    public async ValueTask<string?> FindElementIdAsync(int customerId, string name, CosmosFormCache.CacheType type,
        string hash)
    {
        if(IgnoreFormPrefixes.Any(prefix => name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)))
            return null;
        var query = container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
            c.CustomerId == customerId && c.FormName == name && c.Type == type);
        if(!returnCacheOnMismatch)
            query = query.Where(c=>c.Hash == hash);
        if (cacheLatestOnly)
            query = query.Where(c => c.IsLatest);
        return await query.OrderByDescending(c=>c.Timestamp).Select(c => c.ElementId).FirstOrDefaultItemAsync();
    }

    public ValueTask<string?> FindFormIdByHashAsync(int customerId, string name, string hash)
        => FindElementIdAsync(customerId, name, CosmosFormCache.CacheType.Form, hash);

    public ValueTask<string?> FindFolderIdByHashAsync(int customerId, string name, string hash) 
        => FindElementIdAsync(customerId, name, CosmosFormCache.CacheType.Folder, hash);

    public ValueTask<IDataSource?> FindDataSourceByHashAsync(int customerId, string name, string hash)
        => FindDataSourceIntAsync(customerId, name, hash);

    public async ValueTask<IDataSource?> FindDataSourceIntAsync(int customerId, string name, string? hash = null)
    {
        if(IgnoreFormPrefixes.Any(prefix => name.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)))
            return null;
        var query = container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
            c.CustomerId == customerId && c.FormName == name && c.Type == CosmosFormCache.CacheType.DataSource);
        if (hash != null && !returnCacheOnMismatch)
            query = query.Where(c => c.Hash == hash);
        if (cacheLatestOnly)
            query = query.Where(c => c.IsLatest);
        var result = await query.OrderByDescending(c => c.Timestamp).Select(c => new
            {
                Id = c.ElementId,
                Columns = c.Columns,
            })
            .FirstOrDefaultItemAsync();
        return result == null ? null : new DataSource(result.Id, name, result.Columns);
    }

    public ValueTask<IDataSource?> FindLatestDataSourceAsync(int customerId, string name)
        => FindDataSourceIntAsync(customerId, name);

    private async ValueTask StoreAsync(int customerId, string name, string hash, string id,
        CosmosFormCache.CacheType type, IReadOnlyList<string>? columns = null) =>
        await container.UpsertItemAsync(new CosmosFormCache
        {
            Id = cacheLatestOnly ? $"{customerId}-{type}-{name}" : Guid.NewGuid().ToString(),
            CustomerId = customerId,
            FormName = name,
            Hash = hash,
            ElementId = id,
            Type = type,
            Columns = columns?.ToList() ?? [],
            IsLatest = cacheLatestOnly,
            TimeToLive = (int)CacheDuration.TotalSeconds,
            Timestamp = DateTimeOffset.UtcNow
        });

    public  ValueTask StoreFormIdAsync(int customerId, string name, string hash, string id) =>
        StoreAsync(customerId, name, hash, id, CosmosFormCache.CacheType.Form);


    public ValueTask StoreFolderIdAsync(int customerId, string name, string hash, string id) =>
        StoreAsync(customerId, name, hash, id, CosmosFormCache.CacheType.Folder);
        

    public ValueTask StoreDataSourceAsync(int customerId, string hash, IDataSource dataSource) =>
        StoreAsync(customerId, dataSource.Name, hash, dataSource.Id, CosmosFormCache.CacheType.DataSource, dataSource.Columns);

    public async ValueTask<string?> FindGroupIdAsync(int customerId, string name) =>
        await container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
                c.CustomerId == customerId && c.FormName == name)
            .Where(c => c.Type == CosmosFormCache.CacheType.Group)
            .Select(c => c.ElementId)
            .FirstOrDefaultItemAsync();

    public async Task<string?> FindGroupNameAsync(int customerId, string groupId) =>
        await container.GetItemLinqQueryable<CosmosFormCache>().Where(c =>
                c.CustomerId == customerId && c.ElementId == groupId)
            .Where(c => c.Type == CosmosFormCache.CacheType.Group)
            .Select(c => c.FormName)
            .FirstOrDefaultItemAsync();

    public ValueTask StoreGroupIdAsync(int customerId, string name, string id)
     => StoreAsync(customerId, name, id, id, CosmosFormCache.CacheType.Group);
    
}