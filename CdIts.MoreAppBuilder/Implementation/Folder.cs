namespace MoreAppBuilder.Implementation;

internal class Folder : IFolder
{
    private readonly RestClient _client;

    public Folder(RestClient client, string id, string uid, string name)
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

    public IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string id, string? languageId = null)
    {
        return new MultiLangFormBuilder(_client, data, id, languageId ?? id, this);
    }

    public string Id { get; }
    public string Uid { get; }
    public string Name { get; }
}