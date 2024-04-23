using System.Security.Cryptography;
using System.Text;

namespace MoreAppBuilder.Implementation;

internal class FormContainer<T> : Element<T>, IFormContainer where T : class
{
    protected readonly List<Element> Elements = new();

    

    protected FormContainer() : base("com.moreapps:detail:1")
    {
    }

    public IHtmlElement AddHtml(string data)
    {
        var element = new HtmlElement(data);
        Elements.Add(element);
        return element;
    }

    public ILabelElement AddLabel(string data)
    {
        var element = new LabelElement(data);
        Elements.Add(element);
        return element;
    }

    public IHeaderElement AddHeader(string data, HeaderElementSize size = HeaderElementSize.H2)
    {
        var element = new HeaderElement(data, size);
        Elements.Add(element);
        return element;
    }

    public IImageElement AddImage(string resourceId)
    {
        var element = new ImageElement(resourceId);
        Elements.Add(element);
        return element;
    }

    public ILookupElement AddLookup(string id, string label)
    {
        var element = new LookupElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IRadioElement AddRadio(string id, string label)
    {
        var element = new RadioElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ISignatureElement AddSignature(string id, string label)
    {
        var element = new SignatureElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ISliderElement AddSlider(string id, string label)
    {
        var element = new SliderElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ISearchElement AddSearch(string id, string label, IDataSource dataSoruce)
    {
        var element = new SearchElement(id, label, dataSoruce as DataSource);
        Elements.Add(element);
        return element;
    }

    public IPhotoElement AddPhoto(string id, string label)
    {
        var element = new PhotoElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IBarcodeScannerElement AddBarcodeScanner(string id, string label)
    {
        var element = new BarcodeScannerElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ICheckboxItem AddCheckbox(string id, string label)
    {
        var element = new CheckboxItem(id, label);
        Elements.Add(element);
        return element;
    }

    public ITextAreaElement AddTextArea(string id, string label)
    {
        var element = new TextAreaElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ISubFormElement AddSubForm(string id, string label)
    {
        var element = new SubFormElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IDrawingElement AddDrawing(string id, string label)
    {
        var element = new DrawingElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IDateElement AddDate(string id, string label)
    {
        var element = new DateElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ITimeElement AddTime(string id, string label)
    {
        var element = new TimeElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IDateTimeElement AddDateTime(string id, string label)
    {
        var element = new DateTimeElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IEmailElement AddEmail(string id, string label)
    {
        var element = new EmailElement(id, label);
        Elements.Add(element);
        return element;
    }

    public INumberElement AddNumber(string id, string label)
    {
        var element = new NumberElement(id, label);
        Elements.Add(element);
        return element;
    }

    public IPhoneElement AddPhone(string id, string label)
    {
        var element = new PhoneElement(id, label);
        Elements.Add(element);
        return element;
    }

    public ITextElement AddText(string id, string label)
    {
        var element = new TextElement(id, label);
        Elements.Add(element);
        return element;
    }
}