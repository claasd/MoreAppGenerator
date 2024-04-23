using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class SubFormElement : FormContainer<ISubFormElement>, ISubFormElement
{
    internal override void Consolidate()
    {
        Elements.ForEach(e=>e.Consolidate());
        Field.Properties["form"] = new SubForm
        {
            Uid = Guid.NewGuid().ToString("N")[..24],
            Fields = Elements.Select(e => e.Field).ToList(),
            Rules = Elements.Where(e => e.Rule != null).Select((e, index) => e.Rule!.ToRule(e.Field.Uid, $"#{index}")).ToList(),
            Settings = new Settings
            {
                Interaction = Settings.InteractionValue.MANUAL_UPLOAD,
                SaveMode = Settings.SaveModeValue.SAVE_AND_CLOSE_ONLY,
                SearchSettings = new SearchSettings()
            }
        };
    }
    internal override string HashValue()
    {
        var props = new Dictionary<string, object>(Field.Properties);
        props.Remove("form");
        return Hash(Field.Widget, JsonConvert.SerializeObject(props), Rule?.HashValue(), Hash(Elements.Select(e => e.HashValue()).ToArray()));
    }

    public SubFormElement(string id, string label)
    {
        Field.Properties["data_name"] = id.Trim();
        Field.Properties["label_text"] = label.Trim();
        Field.Properties["add_button_text"] = "Add";
        Field.Properties["itemHtml"] = "Item";
    }

    public ISubFormElement Minimum(int i)
    {
        Field.Properties["min_items"] = i;
        return this;
    }

    public ISubFormElement Maximum(int i)
    {
        Field.Properties["max_items"] = i;
        return this;
    }

    public ISubFormElement ItemDescription(string desc)
    {
        Field.Properties["itemHtml"] = desc;
        return this;
    }

    public ISubFormElement AddButtonText(string label)
    {
        Field.Properties["add_button_text"] = label;
        return this;
    }

    public ISubFormElement Id(string identifier)
    {
        Field.Properties["data_name"] = identifier.Trim();
        return this;
    }

    public ISubFormElement Label(string label)
    {
        Field.Properties["label_text"] = label.Trim();
        return this;
    }
}