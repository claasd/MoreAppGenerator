namespace MoreAppBuilder;

public interface IGroupBuilder
{
    Task<IGroup> BuildAsync(bool allowUseCache = true);
}

public interface IGroup
{
    string Id { get; }
    string Name { get; }
    bool ExternallyManaged { get; }
}