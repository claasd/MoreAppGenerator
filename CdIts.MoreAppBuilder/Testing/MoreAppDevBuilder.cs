namespace MoreAppBuilder.Debug;

public class MoreAppDevBuilder(MoreAppDevFactory? factory = null) : IMoreAppBuilder
{
    public MoreAppDevFactory Factory { get; set; } = factory ?? new MoreAppDevFactory();

    public IFolderBuilder Folder(string id, string name) => Factory.Folder(id, name);

    public IMultiLangFolderBuilder Folder(MoreAppLanguageInstance languageData, string id, string? langSectionId = null)
    => Factory.MultiLangFolder(languageData, id, langSectionId);

    public IGroupBuilder Group(string name, string? groupIdHint = null) => Factory.Group(name, groupIdHint);

    public IUserBuilder User(string email)
    {
        throw new NotImplementedException();
    }

    public IFormBuilder Form(string id, string name, IFolder? folder = null) => Factory.Form(id, name, folder);
    
    public IUrlDataSourceBuilder UrlDataSource(string name, string url) => Factory.UrlDataSource(name, url);

    public IWebHookBuilder WebHook(string name, string url)
    {
        throw new NotImplementedException();
    }
}
