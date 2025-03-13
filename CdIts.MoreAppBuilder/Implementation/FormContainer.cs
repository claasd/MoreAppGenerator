using Microsoft.AspNetCore.Mvc.Razor;

namespace MoreAppBuilder.Implementation;

internal interface IGenericFormContainer : IFormContainer
{
    TElem AddElement<TElem>(TElem element) where TElem : Element;
    List<Element> Elements { get; }
}

internal class FormContainer<T> : Element<T>, IGenericFormContainer where T : class
{
    public List<Element> Elements { get; protected set; } = new();
    protected FormContainer() : base("com.moreapps:detail:1")
    {
    }

    public TElem AddElement<TElem>(TElem element) where TElem : Element
    {
        Elements.Add(element);
        return element;
    }

    public IHtmlElement AddHtml(string data) => AddElement(new HtmlElement(data));
    public IHtmlElement AddCard(CardType type, string title, string[] lines)
    {
        var (borderColor, textColor, bgColor) = GetCardColors(type);
        var data = string.Join("\n", lines.Select(line => $"<p style=\"margin: 0\">{line}</p>"));
        var style = $"border: 1px solid {borderColor};background-color: {bgColor}; color: {textColor}; padding: 10px; margin: 5px; border-radius: 5px;";
        return AddHtml($"<div style=\"{style}\"><h3 style=\"text-align:center; margin-top: 2px\">{title}</h3>{data}</div>");
    }
    
    private static (string BorderColor, string TextColor, string BgColor) GetCardColors(CardType type)
    {
        return type switch
        {
            CardType.Info => ("#17a2b8", "#0c5460", "#d1ecf1"), // Info: Light Blue
            CardType.Success => ("#28a745", "#155724", "#d4edda"), // Success: Green
            CardType.Warning => ("#ffc107", "#856404", "#fff3cd"), // Warning: Yellow
            CardType.Error => ("#dc3545", "#721c24", "#f8d7da"), // Danger: Red
            _ => ("#6c757d", "black", "white") // Fallback (same as Default)
        };
    }

    public IHtmlElement AddHtmlSection(string title, string singleLine, HeaderElementSize size = HeaderElementSize.H3) =>
        AddHtmlSection(title, size, singleLine);

    public IHtmlElement AddHtmlSection(string title, params string[] lines) => AddHtmlSection(title, HeaderElementSize.H3, lines);

    public IHtmlElement AddHtmlSection(string title, HeaderElementSize size, params string[] lines)
    {
        var data = string.Join("\n", lines.Select(line => $"<p style=\"margin: 0\">{line}</p>"));
        return AddHtml($"<hr/><{size} style=\"text-align:center\">{title}</{size}>{data}");
    }

    public ILabelElement AddLabel(string data) => AddElement(new LabelElement(data));

    public IHeaderElement AddHeader(string data, HeaderElementSize size = HeaderElementSize.H2) => AddElement(new HeaderElement(data, size));

    public IImageElement AddImage(string resourceId) => AddElement(new ImageElement(resourceId));

    public ILookupElement AddLookup(string id, string label) => AddElement(new LookupElement(id, label));

    public IRadioElement AddRadio(string id, string label) => AddElement(new RadioElement(id, label));

    public ISignatureElement AddSignature(string id, string label) => AddElement(new SignatureElement(id, label));

    public ISliderElement AddSlider(string id, string label) => AddElement(new SliderElement(id, label));

    public ISearchElement AddSearch(string id, string label, IDataSource dataSource) => AddElement(new SearchElement(id, label, dataSource as DataSource));

    public IPhotoElement AddPhoto(string id, string label) => AddElement(new PhotoElement(id, label));
    public IFileElement AddFile(string id, string label) => AddElement(new FileElement(id, label));

    public IBarcodeScannerElement AddBarcodeScanner(string id, string label) => AddElement(new BarcodeScannerElement(id, label));

    public ICheckboxItem AddCheckbox(string id, string label) => AddElement(new CheckboxItem(id, label));

    public ITextAreaElement AddTextArea(string id, string label) => AddElement(new TextAreaElement(id, label));

    public ISubFormElement AddSubForm(string id, string label) => AddElement(new SubFormElement(id, label));

    public IDrawingElement AddDrawing(string id, string label) => AddElement(new DrawingElement(id, label));
    public ILocation AddLocation(string id, string label) => AddElement(new LocationElement(id, label));
    public IReadOnlyText AddReadOnlyText(string id, string label) => AddElement(new ReadOnlyTextElement(id, label));

    public IDateElement AddDate(string id, string label) => AddElement(new DateElement(id, label));

    public ITimeElement AddTime(string id, string label) => AddElement(new TimeElement(id, label));

    public IDateTimeElement AddDateTime(string id, string label) => AddElement(new DateTimeElement(id, label));

    public IEmailElement AddEmail(string id, string label) => AddElement(new EmailElement(id, label));

    public INumberElement AddNumber(string id, string label) => AddElement(new NumberElement(id, label));

    public IPhoneElement AddPhone(string id, string label) => AddElement(new PhoneElement(id, label));

    public ITextElement AddText(string id, string label) => AddElement(new TextElement(id, label));

    public ITimeCalculation AddTimeCalculation(string id, string label, ITimeElement start, ITimeElement end) => AddElement(new TimeCalculation(id, label, start, end));
    public ICatalogueItem AddCatalogue(string id, string label, IDataSource dataSource) => AddElement(new CatalogueItem(id, label, dataSource as DataSource));
    public IRatingElement AddRating(string id, string label) => AddElement(new RatingItem(id, label));
    public ISmileyElement AddSmiley(string id, string label) => AddElement(new SmileyElement(id, label));


    public ITimeCalculation AddTimeCalculation(string id, string label, IDateTimeElement start, IDateTimeElement end) => AddElement(new TimeCalculation(id, label, start, end));
}