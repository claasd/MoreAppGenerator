namespace MoreAppBuilder;

public interface IDataSource
{
    public string Id { get; }
    public string Name { get; }
    public IReadOnlyList<string> Columns { get; }
}