namespace MoreAppBuilder.Implementation;

internal class MoreAppBuilder(RestClient client, IMoreAppCaching caching) : IMoreAppBuilder
{
    private readonly Dictionary<string, string> _createdFormNames = [];
    private readonly Dictionary<string, string> _createdFormFolders = [];
    public IFolderBuilder Folder(string id, string name) => new FolderBuilder(client, caching, this, id, name);

    public IMultiLangFolderBuilder Folder(MoreAppLanguageInstance languageData, string id, string? langSectionId = null)
        => new MultiLangFolderBuilder(client, caching, this, languageData, id, langSectionId ?? id);


    public IGroupBuilder Group(string name, string? groupIdHint = null)
        => new GroupBuilder(client, caching, name, groupIdHint);

    public IUserBuilder User(string email)
        => new UserBuilder(client, email);

    public IFormBuilder Form(string id, string name, IFolder? folder = null)
    {
        DuplicateHandling(id, name, folder?.Name);
        return new FormBuilder(client, caching, id, name, folder);
    }

    public IMultiLangFormBuilder Form(MoreAppLanguageInstance data, string id, string? languageId = null,
        IFolder? folder = null)
    {
        DuplicateHandling(id, data.FormName(languageId ?? id), folder?.Name);
        return new MultiLangFormBuilder(client, caching, data, id, languageId ?? id, folder);
    }

    public IUrlDataSourceBuilder UrlDataSource(string name, string url)
        => new UrlDataSourceBuilder(client, name, url, caching);

    public IWebHookBuilder WebHook(string name, string url) => new WebHookBuilder(client, name, url);

    private void DuplicateHandling(string id, string name, string? folderName)
    {
        if (_createdFormNames.TryGetValue(id, out var lastName))
        {
            var lastFolderName = _createdFormFolders.GetValueOrDefault(id);
            throw new InvalidOperationException(
                $"form with id '{id}' already exists with name '{lastName}' in folder '{lastFolderName}'. New name: '{name}' in folder '{folderName}' would overwrite it. Please use a different id or name.");
        }

        _createdFormNames[id] = name;
        if (folderName != null)
            _createdFormFolders[id] = folderName;
    }
}