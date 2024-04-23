namespace MoreAppBuilder.Implementation;

internal class TimeElement : InputElement<ITimeElement>, ITimeElement
{
    public TimeElement(string id, string label) : base("com.moreapps:time:1", id, label)
    {
        Field.Properties["now_as_default"] = false;
    }

    public ITimeElement SetNowAsDefault()
    {
        Field.Properties["now_as_default"] = true;
        return this;
    }
}