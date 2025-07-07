namespace MoreAppBuilder.Implementation;

internal class FolderInfo
{
    public string Id { get; set;  } = string.Empty;
    public string Uid { get; set;  } = string.Empty;
    public string Name { get; set;  } = string.Empty;
}
internal class Folder(RestClient client, IMoreAppCaching caching, string id, string uid, string name)
    : IFolder
{
    public IFormBuilder Form(string id, string name)
    {
        return new FormBuilder(client, caching, id, name, folder: this);
    }

    public IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string formId, string? languageId = null)
    {
        return new MultiLangFormBuilder(client, caching, data, formId, languageId ?? formId, this);
    }

    public string Id { get; } = id;
    public string Uid { get; } = uid;
    public string Name { get; } = name;
}

internal class MultiLangFolder(
    RestClient client,
    IMoreAppCaching caching,
    MoreAppLanguageInstance languageData,
    string id,
    string uid,
    string name)
    : Folder(client, caching, id, uid, name), IMultiLangFolder
{
    public IMultiLangFormBuilder MultiLangForm(string formId, string? languageId = null) =>
        MultiLangForm(languageData, formId, languageId);

    public string Language => languageData.Language;
}