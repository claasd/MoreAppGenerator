namespace MoreAppBuilder.Implementation;

internal class RatingItem : InputElement<IRatingElement>, IRatingElement
{
    public RatingItem(string id, string label) : base("com.moreapps.plugins:rating:10", id, label, false)
    {
        Field.Properties["rateScale"] = 5;
    }

    public IRatingElement Scale(int scale)
    {
        Field.Properties["rateScale"] = scale;
        return this;
    }
}