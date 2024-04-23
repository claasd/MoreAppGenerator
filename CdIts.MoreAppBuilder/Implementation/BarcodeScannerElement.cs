using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class BarcodeScannerElement : InputElement<IBarcodeScannerElement>, IBarcodeScannerElement
{
    public BarcodeScannerElement(string id, string label) : base("com.moreapps:barcode:1", id, label)
    {
    }
}