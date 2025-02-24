using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class EmailElement : InputElementWithPlaceholder<IEmailElement>, IEmailElement
{
    public EmailElement(string id, string label) : base("com.moreapps:email:1", id, label)
    {
        SetPlaceholder("me@moreapp.dev");
        Field.Properties["text_default_value"] = "";
    }

    public IEmailElement SetDefault(string defaultValue)
    {
        Field.Properties["text_default_value"] = defaultValue;
        return this;
    }
}