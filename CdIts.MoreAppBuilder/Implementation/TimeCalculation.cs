using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class TimeCalculation : InputElement<ITimeCalculation>, ITimeCalculation
{
    private Element? _start;
    private Element? _end;
    protected internal TimeCalculation(string id, string label, IDateTimeElement start, IDateTimeElement end) : base("com.moreapps.plugins:timecalculation:4", id, label, false)
    {
        _start = start as Element;
        _end = end as Element;
        SetFields();
    }
    protected internal TimeCalculation(string id, string label, ITimeElement start, ITimeElement end) : base("com.moreapps.plugins:timecalculation:4", id, label, false)
    {
        _start = start as Element;
        _end = end as Element;
        SetFields();
    }

    internal override string HashValue()
    {
        var props = new Dictionary<string, object>(Field.Properties);
        // replace filter fields with names to avoid new hashes every time
        props["start"] = _start?.Field.Properties["data_name"] ?? "";
        props["end"] = _end?.Field.Properties["data_name"] ?? "";
        return Hash(Field.Widget, JsonConvert.SerializeObject(props), JsonConvert.SerializeObject(Rules));
    }
    
    private void SetFields()
    {
        Field.Properties["start"] = _start?.Field.Uid;
        Field.Properties["end"] = _end?.Field.Uid;
    }
}