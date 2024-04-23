using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class HtmlElement : Element<IHtmlElement>, IHtmlElement
{
    public HtmlElement(string data) : base("com.moreapps:html:1")
    {
        Field.Properties["html_code"] = data;
    }
}

internal class LabelElement : Element<ILabelElement>, ILabelElement
{
    public LabelElement(string data) : base("com.moreapps:label:1")
    {
        Field.Properties["label_text"] = data;
    }
}

internal class HeaderElement : Element<IHeaderElement>, IHeaderElement
{
    public HeaderElement(string data, HeaderElementSize size) : base("com.moreapps:header:1")
    {
        Field.Properties["label_text"] = data;
        Field.Properties["size"] = size.ToString().ToLower();
    }
}