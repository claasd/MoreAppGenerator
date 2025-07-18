using MoreAppBuilder.Implementation;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Testing;

internal class LocalTestingFormBuilder(string id, string label, IFolder? folder) :  FormContainer<IFormBuilder>, IFormBuilder, IFormInfo
{
    public string Id { get; } = Guid.NewGuid().ToString("N");
    string IFormInfo.Name => id;
    public string Label { get; private set; } = label;
    public IReadOnlyCollection<string> Tags { get; } = [];
    public IFormBuilder Tag(string tag) => this;
    public IFormBuilder Icon(string icon) => this;

    public IFormBuilder InAppDescription(string inAppDesc) => this;
    public IFormBuilder Name(string label)
    {
        Label = label;
        return this;
    }

    public async Task<IFormInfo> BuildAsync(bool removeDrafts = true)
    {
        await Task.Yield(); 
        return this;
    }

    public string GetHash()
    {
        throw new NotImplementedException();
    }

    public string CreateOpenApiSpec()
    {
        throw new NotImplementedException();
    }

    public IFormBuilder Description(string desc) => this;
    public IFormBuilder AddToGroup(IGroup group) => this;
    public IFormBuilder FolderPosition(int position) => this;

    public static JObject Json(IEnumerable<Element> elements)
    {
        var data = new JObject();
        foreach (var element in elements)
        {
            if(!element.Field.Properties.ContainsKey("data_name"))
                continue;
            var name = element.Field.Properties["data_name"].ToString()!;
            if (element is MultiLangSubFormElement sub1)
                data[name] = new JArray() { Json(sub1.Elements) };
            else if (element is SubFormElement sub2)
                data[name] = new JArray() { Json(sub2.Elements) };
            else if (element is SearchElement { DataSource: LocalTestingDataSource devDataSource })
                data[name] = JObject.FromObject(devDataSource.Data);
            else if (element is PhotoElement or DrawingElement)
                data[name] = $"gridfs://registrationFiles/{Guid.NewGuid()}";
            else if (element is CheckboxItem)
                data[name] = true;
            else if (element.Field.Properties.TryGetValue("default_value", out var defaultValue) && !string.IsNullOrWhiteSpace(defaultValue?.ToString()))
                data[name] = defaultValue.ToString();
            else if (element.Field.Properties.TryGetValue("radio_options", out var radioOptions) && radioOptions is ICollection<string> radioOptionList && radioOptionList.Any())
                data[name] = radioOptionList.FirstOrDefault();
            else
                data[name] = element.Field.Properties["label_text"].ToString();
        }

        return data;
    }
    public string Json() => Json(Elements).ToString();
}