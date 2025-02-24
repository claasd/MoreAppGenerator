using MoreAppBuilder.Implementation.Client;

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

    public static async Task<IDataSource> LoadAsync(RestClient client, string name)
    {
        var dsClient = new MoreAppDatasourcesClient(client.HttpClient);
        var list = await dsClient.GetAllAsync(client.CustomerId);
        var current = list.FirstOrDefault(item => item.Name == name);
        if(current is null)
            throw new InvalidOperationException($"Datasource {name} not found");
        return new DataSource(current.Id, current.Name, current.ColumnMapping.Select(m => m.Id).ToList());
    }
}