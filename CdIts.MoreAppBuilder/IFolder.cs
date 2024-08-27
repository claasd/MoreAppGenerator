namespace MoreAppBuilder;

public interface IFolderBuilder
{
    IFolderBuilder Icon(string icon);
    IFolderBuilder Description(string description);
    IFolderBuilder HideInApp();
    Task<IFolder> BuildAsync();
    public string Name { get; set; }
}

public interface IMultiLangFolderBuilder : IFolderBuilder
{
    new IMultiLangFolderBuilder Icon(string icon);
    new IMultiLangFolderBuilder HideInApp();
    new IMultiLangFolderBuilder Description(string description);
    new Task<IMultiLangFolder> BuildAsync();
}

public interface IFolder
{
    string Id { get; }
    string Uid { get; }
    string Name { get; }
    IFormBuilder Form(string id, string name);
    IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string formId, string? languageId = null);
}

public interface IMultiLangFolder : IFolder
{
    IMultiLangFormBuilder MultiLangForm(string formId, string? languageId = null);
    public string Language { get; }
}
