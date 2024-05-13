using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class LookupElement : InputElement<ILookupElement>, ILookupElement
{
    private readonly List<LookupOption> _options = [];
    private readonly List<string> _defaults = [];
    private bool _isMultiple;

    internal override void Consolidate()
    {
        Field.Properties["is_multiple"] = _isMultiple;
        Field.Properties["options"] = _options;
        if (_isMultiple && _defaults.Any())
            Field.Properties["default_value"] = _defaults;
        else
            Field.Properties["default_value"] = _defaults.FirstOrDefault();
        base.Consolidate();
    }

    public LookupElement(string id, string label) : base("com.moreapps:lookup:1", id, label)
    {
        Field.Properties["options"] = _options;
        Field.Properties["is_multiple"] = false;
        Field.Properties["default_value"] = null;
        Field.Properties["sort_alphabetically"] = false;
        Field.Properties["expand"] = false;
    }

    public ILookupElement AddOption(string id, string desc, bool isDefault = false)
    {
        _options.Add(new LookupOption()
        {
            Id = id,
            Name = desc
        });

        if (isDefault)
            _defaults.Add(id);
        return this;
    }

    public ILookupElement MultiSelection()
    {
        _isMultiple = true;
        return this;
    }

    public ILookupElement AddOptions(IEnumerable<KeyValuePair<string, string>> options)
    {
        foreach (var (id, value) in options)
        {
            AddOption(id, value);
        }

        return this;
    }

    public ILookupElement AddRange(int first, int last)
    {
        for (var i = first; i <= last; i++)
            AddOption(i.ToString(), i.ToString());
        return this;
    }
}