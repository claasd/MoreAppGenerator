using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

public interface IFormContainer
{
    IHtmlElement AddHtml(string data);
    IImageElement AddImage(string resourceId);
    ILabelElement AddLabel(string data);
    IHeaderElement AddHeader(string data, HeaderElementSize size = HeaderElementSize.H2);
    ILookupElement AddLookup(string id, string label);
    IRadioElement AddRadio(string id, string label);
    ISignatureElement AddSignature(string id, string label);
    ISliderElement AddSlider(string id, string label);
    ISearchElement AddSearch(string id, string label, IDataSource dataSoruce);
    IPhotoElement AddPhoto(string id, string label);
    IBarcodeScannerElement AddBarcodeScanner(string id, string label);
    ICheckboxItem AddCheckbox(string id, string label);
    IDateElement AddDate(string id, string label);
    ITimeElement AddTime(string id, string label);
    IDateTimeElement AddDateTime(string id, string label);
    IEmailElement AddEmail(string id, string label);
    INumberElement AddNumber(string id, string label);
    IPhoneElement AddPhone(string id, string label);
    ITextElement AddText(string id, string label);
    ITextAreaElement AddTextArea(string id, string label);
    ISubFormElement AddSubForm(string id, string label);
    IDrawingElement AddDrawing(string id, string label);
 }

public interface IFormBuilder : IFormContainer
{
    IFormBuilder Tag(string tag);
    Task<IFormInfo> BuildAsync();
    IFormBuilder Description(string desc);
}

public interface IFormInfo
{
    string Id { get; }
    string Name { get; }
    string Label { get; }
    IReadOnlyCollection<string> Tags { get; }
}