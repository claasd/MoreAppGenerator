namespace MoreAppBuilder.Implementation;

internal class SignatureElement : InputElement<ISignatureElement>, ISignatureElement
{
    public SignatureElement(string id, string label) : base("com.moreapps:signature:1", id, label, false)
    {
        Field.Properties["stroke_width"] = 1;
        Field.Properties["wide"] = false;
    }

    public ISignatureElement PenWidth(int penWidth)
    {
        Field.Properties["stroke_width"] = penWidth;
        return this;
    }

    public ISignatureElement Wide()
    {
        Field.Properties["wide"] = true;
        return this;
    }
}