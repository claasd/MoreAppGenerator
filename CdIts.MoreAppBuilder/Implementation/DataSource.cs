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
}