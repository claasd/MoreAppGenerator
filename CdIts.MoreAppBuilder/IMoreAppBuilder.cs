namespace MoreAppBuilder;

public interface IMoreAppBuilder
{
    IFolderBuilder Folder(string id, string name);

    IFormBuilder Form(string id, string name, IFolder? folder = null);

    IUrlDataSourceBuilder UrlDataSource(string name, string url);

    IWebHookBuilder WebHook(string name, string url);
}