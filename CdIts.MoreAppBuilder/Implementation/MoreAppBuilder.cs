namespace MoreAppBuilder.Implementation;

internal class MoreAppBuilder(RestClient client, IMoreAppCaching caching) : IMoreAppBuilder
{
    public IFolderBuilder Folder(string id, string name)
    {
        return new FolderBuilder(client, caching,  id, name);
    }

    public IMultiLangFolderBuilder Folder(MoreAppLanguageInstance languageData, string id, string? langSectionId = null)
    {
        return new MultiLangFolderBuilder(client, caching, languageData, id, langSectionId ?? id);
    }


    public IGroupBuilder Group(string name, string? groupIdHint = null)
    {
        return new GroupBuilder(client, name, groupIdHint);
    }

    public IUserBuilder User(string email)
    {
        return new UserBuilder(client, email);
    }

    public IFormBuilder Form(string id, string name, IFolder? folder = null)
    {
        return new FormBuilder(client, caching, id, name, folder);
    }

    public IUrlDataSourceBuilder UrlDataSource(string name, string url)
    {
        return new UrlDataSourceBuilder(client, name, url, caching);
    }

    public IWebHookBuilder WebHook(string name, string url)
    {
        return new WebHookBuilder(client, name, url);
    }
}