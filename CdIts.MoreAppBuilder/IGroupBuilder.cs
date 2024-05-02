namespace MoreAppBuilder;

public interface IGroupBuilder
{
    Task<IGroup> BuildAsync();
}

public interface IGroup
{
    string Id { get; }
    string Name { get; }
}