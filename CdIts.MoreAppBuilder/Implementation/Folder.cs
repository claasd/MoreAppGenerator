namespace MoreAppBuilder.Implementation;

internal class Folder : IFolder
{
    private readonly RestClient _client;

    internal Folder(RestClient client, string id, string uid, string name)
    {
        _client = client;
        Id = id;
        Uid = uid;
        Name = name;
    }
    public IFormBuilder Form(string id, string name)
    {
        return new FormBuilder(_client, id, name, this);
    }

    public IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string formId, string? languageId = null)
    {
        return new MultiLangFormBuilder(_client, data, formId, languageId ?? formId, this);
    }

    public string Id { get; }
    public string Uid { get; }
    public string Name { get; }
}

internal class MultiLangFolder : Folder, IMultiLangFolder
{
    private readonly MoreAppLanguageInstance _languageData;

    public MultiLangFolder(RestClient client, MoreAppLanguageInstance languageData, string id, string uid, string name) : base(client, id, uid, name)
    {
        _languageData = languageData;
    }

    public IMultiLangFormBuilder MultiLangForm(string formId, string? languageId = null) => MultiLangForm(_languageData, formId, languageId);
    public string Language => _languageData.Language;
}