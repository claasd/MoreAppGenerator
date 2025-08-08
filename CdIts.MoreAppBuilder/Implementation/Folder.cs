namespace MoreAppBuilder.Implementation;

internal class FolderInfo
{
    public string Id { get; set; } = string.Empty;
    public string Uid { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}

internal class Folder(IMoreAppBuilder builder, string id, string uid, string name)
    : IFolder
{
    public IFormBuilder Form(string id, string name) => builder.Form(id, name, this);

    public IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string formId, string? languageId = null)
        => builder.Form(data, formId, languageId, this);

    public string Id { get; } = id;
    public string Uid { get; } = uid;
    public string Name { get; } = name;
}

internal class MultiLangFolder(
    IMoreAppBuilder builder,
    MoreAppLanguageInstance languageData,
    string id,
    string uid,
    string name)
    : Folder(builder, id, uid, name), IMultiLangFolder
{
    public IMultiLangFormBuilder MultiLangForm(string formId, string? languageId = null) =>
        MultiLangForm(languageData, formId, languageId);

    public string Language => languageData.Language;
}