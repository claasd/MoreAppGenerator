namespace MoreAppBuilder.Debug;

class MoreAppDevFolderBuilder(MoreAppDevFactory factory, string id, string name) : IFolderBuilder, IFolder
{
    public string Id { get; } = id;
    public string Uid { get; } = Guid.NewGuid().ToString("N");
    public string Name { get; set; } = name;
    public IFormBuilder Form(string id, string name) => Factory.Form(id, name, this);

    public IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string formId, string? languageId = null) => 
        Factory.MultiLangForm(data, formId, this, languageId);

    public MoreAppDevFactory Factory { get; set; } = factory;
    public IFolderBuilder Icon(string icon) => this;
    public IFolderBuilder Description(string description) => this;
    public IFolderBuilder HideInApp() => this;
    public Task<IFolder> BuildAsync() => Task.FromResult<IFolder>(this);
}