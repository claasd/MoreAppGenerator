namespace MoreAppBuilder.Implementation;

internal class TimeCalculation : InputElement<ITimeCalculation>, ITimeCalculation
{
    protected internal TimeCalculation(string id, string label, IDateTimeElement start, IDateTimeElement end) : base("com.moreapps.plugins:timecalculation:4", id, label, false)
    {
        SetFields(start as Element, end as Element);
    }
    protected internal TimeCalculation(string id, string label, ITimeElement start, ITimeElement end) : base("com.moreapps.plugins:timecalculation:4", id, label, false)
    {
        SetFields(start as Element, end as Element);
    }

    private void SetFields(Element? start, Element? end)
    {
        Field.Properties["start"] = start?.Field.Uid;
        Field.Properties["end"] = end?.Field.Uid;
    }
}