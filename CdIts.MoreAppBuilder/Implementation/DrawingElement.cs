namespace MoreAppBuilder.Implementation;

internal class DrawingElement : InputElement<IDrawingElement>, IDrawingElement
{
    internal DrawingElement(string id, string label) : base("com.moreapps.plugins:drawing:5", id, label, false)
    {
    }
}