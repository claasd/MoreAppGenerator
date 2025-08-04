using MoreAppBuilder.Implementation.Client;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

public class DataSource : IDataSource
{
    public DataSource(string id, string name, List<string> columns)
    {
        Id = id;
        Name = name;
        Columns = columns;
    }

    public IReadOnlyList<string> Columns { get; }

    public string Id { get; }
    public string Name { get; }

    public static async Task<IDataSource> LoadAsync(RestClient client, string name, IMoreAppCaching caching, bool allowUseCache)
    {
        if (allowUseCache)
        {
            var info = await caching.FindLatestDataSourceAsync(client.CustomerId, name);
            if(info is not null)
                return info;
        }
        var dsClient = new MoreAppDatasourcesClient(client.HttpClient);
        var list = await dsClient.GetAllAsync(client.CustomerId);
        var current = list.FirstOrDefault(item => item.Name == name);
        if(current is null)
            throw new InvalidOperationException($"Datasource {name} not found");

        var result = new DataSource(current.Id, current.Name, current.ColumnMapping.Select(m => m.Id).ToList());
        if(allowUseCache)
        {
            var hash = Element.Hash(JsonConvert.SerializeObject(current));
            await caching.StoreDataSourceAsync(client.CustomerId, hash, result);
        }
        return result;
    }
}