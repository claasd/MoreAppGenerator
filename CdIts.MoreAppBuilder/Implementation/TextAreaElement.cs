namespace MoreAppBuilder.Implementation;

internal class TextAreaElement : InputElementWithPlaceholder<ITextAreaElement>, ITextAreaElement
{
    public TextAreaElement(string id, string label) : base("com.moreapps:text_area:1", id, label)
    {
        Field.Properties["default_value"] = "";
        Field.Properties["max_length"] = 1000;
    }

    public ITextAreaElement SetDefault(string defaultValue)
    {
        Field.Properties["default_value"] = defaultValue;
        return this;
    }

    public ITextAreaElement MaxLength(int minLength)
    {
        Field.Properties["max_length"] = minLength;
        return this;
    }
}