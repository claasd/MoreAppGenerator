using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class RadioElement : InputElement<IRadioElement>, IRadioElement
{
    private List<LookupOption> _options = new();
    internal RadioElement(string id, string label) : base("com.moreapps:radio:1", id, label)
    {
        Field.Properties["use_images_as_labels"] = false;
        Field.Properties["vertical_alignment"] = false;
        Field.Properties["radio_options"] = _options;
    }

    public IRadioElement AddOption(string id, string desc, bool isDefault = false)
    {
        _options.Add(new LookupOption()
        {
            Id = id,
            Name = desc
        });
        Field.Properties["radio_options"] = _options;
        if(isDefault)
            Field.Properties["default_value"] = id;
        return this;
    }

    public IRadioElement VerticalAlignment()
    {
        Field.Properties["vertical_alignment"] = true;
        return this;
    }

    public IRadioElement AddOptions(IEnumerable<KeyValuePair<string, string>> options)
    {
        foreach (var (id, value) in options)
        {
            AddOption(id, value);
        }
        return this;
    }
}