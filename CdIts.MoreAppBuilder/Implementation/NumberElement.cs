namespace MoreAppBuilder.Implementation;

internal class NumberElement : InputElementWithPlaceholder<INumberElement>, INumberElement
{
    public NumberElement(string id, string label) : base("com.moreapps:number:1", id, label)
    {
        Field.Properties["text_placeholder"] = "You should enter a number";
    }

    public INumberElement Minimum(double min)
    {
        Field.Properties["numeric_min"] = min;
        return this;
    }

    public INumberElement Maximum(double max)
    {
        Field.Properties["numeric_max"] = max;
        return this;
    }

    public INumberElement SetDefault(double defaultValue)
    {
        Field.Properties["text_default_value"] = defaultValue;
        return this;
    }
}