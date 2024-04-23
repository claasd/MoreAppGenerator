namespace MoreAppBuilder.Implementation;

internal class TextElement : InputElementWithPlaceholder<ITextElement>, ITextElement
{
    public TextElement(string id, string label) : base("com.moreapps:text:1", id, label)
    {
        Field.Properties["default_value"] = "";
        Field.Properties["max_length"] = 100;
        Field.Properties["min_length"] = 0;
    }
    

    public ITextElement SetDefault(string defaultValue)
    {
        Field.Properties["default_value"] = defaultValue;
        return this;
    }

    public ITextElement MinLength(int minLength)
    {
        Field.Properties["min_length"] = minLength;
        return this;
    }

    public ITextElement MaxLength(int minLength)
    {
        Field.Properties["max_length"] = minLength;
        return this;
    }
}