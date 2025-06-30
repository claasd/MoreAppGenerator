using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class RadioElement<T> : InputElement<T>  where T : class
{
    private List<LookupOption> _options = new();
    internal RadioElement(string id, string label) : base("com.moreapps:radio:1", id, label)
    {
        Field.Properties["use_images_as_labels"] = false;
        Field.Properties["vertical_alignment"] = false;
        Field.Properties["radio_options"] = _options;
    }

    public T AddOption(string id, string desc, bool isDefault = false)
    {
        _options.Add(new LookupOption()
        {
            Id = id,
            Name = desc
        });
        Field.Properties["radio_options"] = _options;
        if(isDefault)
            Field.Properties["default_value"] = id;
        return this as T;
    }

    public T VerticalAlignment()
    {
        Field.Properties["vertical_alignment"] = true;
        return this as T;
    }

    public T AddOptions(IEnumerable<KeyValuePair<string, string>> options)
    {
        foreach (var (id, value) in options)
        {
            AddOption(id, value);
        }
        return this as T;
    }
}

internal class RadioElement : RadioElement<IRadioElement>, IRadioElement
{
    public RadioElement(string id, string label) : base(id, label)
    {
    }
}

internal class MultiLangRadioElement : RadioElement<IMultiLangRadioElement>, IMultiLangRadioElement
{
    private readonly FieldLangLookup _lookup;

    public MultiLangRadioElement(string id, string title, FieldLangLookup lookup) : base(id, title)
    {
        _lookup = lookup;
    }
    public IMultiLangRadioElement AddOption(string id, bool isDefault = false, string? globalConfigSection = null, string? fallbackValue = null)
    {
        return AddOption(id, _lookup.GetOption(id, globalConfigSection: globalConfigSection, defaultValue: fallbackValue ?? id), isDefault);
    }
}