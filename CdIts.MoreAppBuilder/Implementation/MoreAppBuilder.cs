namespace MoreAppBuilder.Implementation;

internal class MoreAppBuilder : IMoreAppBuilder
{
    private readonly RestClient _client;

    internal MoreAppBuilder(RestClient client)
    {
        _client = client;
    }

    public IFolderBuilder Folder(string id, string name)
    {
        return new FolderBuilder(_client, id, name);
    }

    public IFormBuilder Form(string id, string name, IFolder? folder = null)
    {
        return new FormBuilder(_client, id, name, folder);
    }

    public IUrlDataSourceBuilder UrlDataSource(string name, string url)
    {
        return new UrlDataSourceBuilder(_client, name, url);
    }

    public IWebHookBuilder WebHook(string name, string url)
    {
        return new WebHookBuilder(_client, name, url);
    }
}