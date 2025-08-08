namespace MoreAppBuilder;

public interface IMoreAppBuilder
{
    IFolderBuilder Folder(string id, string name);
    
    IMultiLangFolderBuilder Folder(MoreAppLanguageInstance languageData, string id, string? langSectionId = null);
    
    IGroupBuilder Group(string name, string? groupIdHint = null);
    IUserBuilder User(string email);
    IFormBuilder Form(string id, string name, IFolder? folder = null);
    IMultiLangFormBuilder Form(MoreAppLanguageInstance data, string id, string? languageId = null, IFolder? folder = null);
    
    IUrlDataSourceBuilder UrlDataSource(string name, string url);

    IWebHookBuilder WebHook(string name, string url);
}