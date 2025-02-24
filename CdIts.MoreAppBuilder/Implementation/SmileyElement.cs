namespace MoreAppBuilder.Implementation;

internal class SmileyElement : InputElement<ISmileyElement>, ISmileyElement
{
    internal SmileyElement(string id, string label) : base("com.moreapps.plugin:smiley:4", id, label, false)
    {
    }
}