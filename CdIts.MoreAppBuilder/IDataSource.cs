namespace MoreAppBuilder;

public interface IDataSource
{
    public string Id { get; }
    public string Name { get; }
    public IReadOnlyList<string> Columns { get; }
}

public interface IActiveDataSource : IDataSource
{
    bool IsActive { get; }
    DateTimeOffset? LastUpdated { get; }
    DateTimeOffset? LastSuccessfulUpdate { get; }
    string[] ErrorMessages { get; }
}