namespace MoreAppBuilder.Implementation;

internal class NumberElement : InputElementWithPlaceholder<INumberElement>, INumberElement
{
    public NumberElement(string id, string label) : base("com.moreapps:number:1", id, label)
    {
        Field.Properties["text_placeholder"] = "You should enter a number";
    }

    public INumberElement Minimum(int min)
    {
        Field.Properties["numeric_min"] = min;
        return this;
    }

    public INumberElement Maximum(int max)
    {
        Field.Properties["numeric_max"] = max;
        return this;
    }
}