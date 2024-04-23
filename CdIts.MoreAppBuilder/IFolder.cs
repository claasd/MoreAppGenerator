namespace MoreAppBuilder;

public interface IFolderBuilder
{
    IFolderBuilder Icon(string icon);
    IFolderBuilder HideInApp();
    Task<IFolder> BuildAsync();
}

public interface IFolder
{
    string Id { get; }
    string Uid { get; }
    string Name { get; }
    IFormBuilder Form(string id, string name);
}