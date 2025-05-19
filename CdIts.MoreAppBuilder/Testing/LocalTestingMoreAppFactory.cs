using MoreAppBuilder.Implementation;

namespace MoreAppBuilder.Testing;

public class LocalTestingMoreAppFactory
{
    public virtual IFolderBuilder Folder(string id, string name) => new MoreAppDevFolderBuilder(this, id, name);
    public virtual IMultiLangFolderBuilder MultiLangFolder(MoreAppLanguageInstance languageData, string id, string? langSectionId)
    {
        return new LocalTestingMoreAppMultiLangFolderBuilder(this, languageData, id, langSectionId ?? id);
    }

    public virtual IGroupBuilder Group(string name, string? groupIdHint) => new LocalTestingMoreAppGroup(name, groupIdHint);

    public virtual IFormBuilder Form(string id, string name, IFolder? folder) => new LocalTestingFormBuilder(id, name, folder);

    public virtual IUrlDataSourceBuilder UrlDataSource(string name, string url)
    {
        var testData = new Dictionary<string, object>
        {
            ["id"] = "testId",
            ["name"] = "Gandalf"
        };
        return new LocalTestingUrlDataSource(name, url, testData);
    }

    public IMultiLangFormBuilder MultiLangForm(MoreAppLanguageInstance data, string formId, IFolder folder, string? languageId = null)
    {
        return new DevMultiLangFormBuilder(data, formId, folder, languageId ?? formId);
    }
}

internal class DevMultiLangFormBuilder(MoreAppLanguageInstance languageData, string formId, IFolder? folder, string langId)
    : MultiLangFormBuilder(null!, languageData, formId, langId, folder), IFormInfo
{
    public override async Task<IFormInfo> BuildAsync(bool removeDrafts = true)
    {
        await Task.Yield();
        return this;
    }

    public string Id { get; } = Guid.NewGuid().ToString("N");
    string IFormInfo.Name => formId;
    public string Label => "Label not possible for multiLangformData";
    public IReadOnlyCollection<string> Tags { get; } = [];
}