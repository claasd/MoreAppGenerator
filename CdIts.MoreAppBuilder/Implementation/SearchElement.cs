using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class SearchElement : InputElement<ISearchElement>, ISearchElement
{
    internal readonly DataSource DataSource;
    private List<FilterField> _filterfields = new();
    private readonly List<object> _colors = new();

    record FilterField(string Name, string Uid);
    internal override string HashValue()
    {
        var props = new Dictionary<string, object>(Field.Properties);
        // replace filter fields with names to avoid new hashes every time
        props["filter_fields"] = _filterfields.Select(f=>f.Name).ToList();
        return Hash(Field.Widget, JsonConvert.SerializeObject(props), JsonConvert.SerializeObject(Rules));
    }

    protected internal SearchElement(string id, string label, DataSource dataSource) : base("com.moreapps:search:1", id, label)
    {
        DataSource = dataSource;
        Field.Properties["allow_barcode"] = false;
        Field.Properties["remember_search"] = false;
        Field.Properties["default_value"] = "";
        Field.Properties["colors"] = _colors;
        Field.Properties["filter_fields"] = new List<string>();
        VisibleFields(dataSource.Columns.ToArray());
    }

    public ISearchElement VisibleFields(params string[] fields)
    {
        var source = new SearchDataSource
        {
            Id = DataSource.Id,
            Mapping = new(),
        };
        foreach (var field in DataSource.Columns)
        {
            source.Mapping[field] = fields.Contains(field, StringComparer.OrdinalIgnoreCase);
        }

        Field.Properties["data_source_configuration"] = source;
        return this;
    }

    private ISearchElement AddFilter(Element element, string? subField)
    {
        var uid = element.Field.Uid;
        var name = element.Field.Properties["data_name"].ToString()!;
        if (subField != null)
        {
            uid += "." + subField;
            name += "." + subField;
        }
        return AddFilter(name, uid);
    }
    private ISearchElement AddFilter(string name, string uid)
    {
        _filterfields.Add(new FilterField(name, uid));
        _filterfields = _filterfields.DistinctBy(f=>f.Name).OrderBy(f=>f.Name).ToList();
        Field.Properties["filter_fields"] = _filterfields.Select(f=>f.Uid).ToList();
        return this;
    }

    public ISearchElement FilterUserName() => AddFilter("username", "username");
    public ISearchElement Filter<T>(IStringValueField<T> element) => AddFilter((Element)element, null);
    public ISearchElement Filter(IReadOnlyText element) => AddFilter((Element)element, null);

    public ISearchElement Filter(ISearchElement element, string field) => AddFilter((Element)element, field);


    public ISearchElement AllowBarcodeScanner()
    {
        Field.Properties["allow_barcode"] = true;
        return this;
    }

    public ISearchElement RememberLastSearch()
    {
        Field.Properties["remember_search"] = true;
        return this;
    }

    public ISearchElement AddColorQuery(string query, string color)
    {
        _colors.Add(new { query, color });
        Field.Properties["colors"] = _colors.ToList();
        return this;
    }

    public ICondition FieldHasValue(string field)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD_DATA_SOURCE,
            Key = "hasValue",
            Value = true,
            FieldUid = Field.Uid,
            FieldObjectKey = field
        };
    }

    public ICondition FieldHasExactValue(string field, string value)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD_DATA_SOURCE,
            Key = "is",
            Value = value,
            FieldUid = Field.Uid,
            FieldObjectKey = field
        };
    }
    public ICondition FieldContainsValue(string field, string value)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD_DATA_SOURCE,
            Key = "contains",
            Value = value,
            FieldUid = Field.Uid,
            FieldObjectKey = field
        };
    }

    public ICondition FieldHasNoValue(string field)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD_DATA_SOURCE,
            Key = "hasValue",
            Value = false,
            FieldUid = Field.Uid,
            FieldObjectKey = field
        };
    }
}