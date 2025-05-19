namespace MoreAppBuilder.Testing;

internal class LocalTestingMoreAppMultiLangFolderBuilder(LocalTestingMoreAppFactory factory, MoreAppLanguageInstance languageData, string id, string langSectionId)
    : MoreAppDevFolderBuilder(factory, id, languageData.FolderName(langSectionId)), IMultiLangFolderBuilder, IMultiLangFolder
{
    public new IMultiLangFolderBuilder Icon(string icon) => this;

    public new IMultiLangFolderBuilder Description(string description) => this;

    public new async Task<IMultiLangFolder> BuildAsync()
    {
        await Task.Yield();
        return this;
    }

    public new IMultiLangFolderBuilder HideInApp() => this;
    public IMultiLangFormBuilder MultiLangForm(string formId, string? languageId = null) => Factory.MultiLangForm(languageData, formId, this, langSectionId);

    public string Language => languageData.Language;
}