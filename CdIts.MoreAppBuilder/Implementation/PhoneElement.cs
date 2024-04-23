namespace MoreAppBuilder.Implementation;

internal class PhoneElement : InputElementWithPlaceholder<IPhoneElement>, IPhoneElement
{
    internal PhoneElement(string id, string label, bool useRememberInput = true) : base("com.moreapps:phone:1", id, label, useRememberInput)
    {
        SetPlaceholder("+31 (0) 71 523 80 72");
        Field.Properties["text_default_value"] = "";
    }

    public IPhoneElement SetDefault(string defaultValue)
    {
        Field.Properties["text_default_value"] = defaultValue;
        return this;
    }
}