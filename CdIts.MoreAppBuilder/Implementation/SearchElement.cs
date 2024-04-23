using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class SearchElement : InputElement<ISearchElement>, ISearchElement
{
    private readonly DataSource _dataSource;
    private readonly List<string> _filterfields = new();
    protected internal SearchElement(string id, string label, DataSource dataSource) : base("com.moreapps:search:1", id, label)
    {
        _dataSource = dataSource;
        Field.Properties["allow_barcode"] = false;
        Field.Properties["remember_search"] = false;
        Field.Properties["default_value"] = "";
        Field.Properties["colors"] = Array.Empty<string>();
        Field.Properties["filter_fields"] = _filterfields;
        VisibleFields(dataSource.Columns.ToArray());
    }

    public ISearchElement VisibleFields(params string[] fields)
    {
        var source = new SearchDataSource
        {
            Id = _dataSource.Id,
            Mapping = new(),
        };
        foreach (var field in _dataSource.Columns)
        {
            source.Mapping[field] = fields.Contains(field, StringComparer.OrdinalIgnoreCase);
        }
        Field.Properties["data_source_configuration"] = source; 
        return this;
    }

    public ISearchElement FilterUserName()
    {
        _filterfields.Add("username");
        Field.Properties["filter_fields"] = _filterfields.Distinct().ToList();
        return this;
    }

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