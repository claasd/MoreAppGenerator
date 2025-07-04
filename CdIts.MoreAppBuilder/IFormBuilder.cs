using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

public interface IFormContainer
{
    IHtmlElement AddHtml(string data);
    IHtmlElement AddCard(CardType type, string title, string[] lines);
    
    IHtmlElement AddHtmlSection(string title, string singleLine, HeaderElementSize size = HeaderElementSize.H3);
    IHtmlElement AddHtmlSection(string title, HeaderElementSize size, params string[] lines);
    IHtmlElement AddHtmlSection(string title, params string[] lines);
    IImageElement AddImage(string resourceId);
    ILabelElement AddLabel(string data);
    IHeaderElement AddHeader(string data, HeaderElementSize size = HeaderElementSize.H2);
    ILookupElement AddLookup(string id, string label);
    IRadioElement AddRadio(string id, string label);
    ISignatureElement AddSignature(string id, string label);
    ISliderElement AddSlider(string id, string label);
    ISearchElement AddSearch(string id, string label, IDataSource dataSource);
    IPhotoElement AddPhoto(string id, string label);
    IFileElement AddFile(string id, string label);
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
    ILocation AddLocation(string id, string label);
    IReadOnlyText AddReadOnlyText(string id, string label);
    ITimeCalculation AddTimeCalculation(string id, string label, IDateTimeElement start, IDateTimeElement end);
    ITimeCalculation AddTimeCalculation(string id, string label, ITimeElement start, ITimeElement end);
    ICatalogueItem AddCatalogue(string id, string label, IDataSource dataSource);
    IRatingElement AddRating(string id, string label);
    ISmileyElement AddSmiley(string id, string label);
}

public interface IMultiLangFormContainer
{
    IHtmlElement AddHtmlById(string id);
    IHtmlElement AddHtmlSectionById(string id, HeaderElementSize size = HeaderElementSize.H3);
    IHtmlElement AddCardById(CardType type, string id);
    ILabelElement AddLabelById(string id);
    IHeaderElement AddHeaderById(string id, HeaderElementSize size = HeaderElementSize.H2);
    IMultiLangLookupElement AddLookup(string id);
    IMultiLangRadioElement AddRadio(string id);
    ISignatureElement AddSignature(string id);
    ISliderElement AddSlider(string id);
    ISearchElement AddSearch(string id, IDataSource dataSource);
    IPhotoElement AddPhoto(string id);
    IFileElement AddFile(string id);
    IBarcodeScannerElement AddBarcodeScanner(string id);
    ICheckboxItem AddCheckbox(string id);
    IDateElement AddDate(string id);
    ITimeElement AddTime(string id);
    IDateTimeElement AddDateTime(string id);
    IEmailElement AddEmail(string id);
    INumberElement AddNumber(string id);
    IPhoneElement AddPhone(string id);
    ITextElement AddText(string id);
    ITextAreaElement AddTextArea(string id);

    /// <param name="id">The id from the language file</param>
    /// <param name="prefixMode"></param>
    /// <returns></returns>
    IMultiLangSubFormElement AddSubForm(string id, LangPrefixMode prefixMode = LangPrefixMode.FullPrefix);
    IDrawingElement AddDrawing(string id);
    ILocation AddLocation(string id);
    IReadOnlyText AddReadOnlyText(string id);
    ITimeCalculation AddTimeCalculation(string id, IDateTimeElement start, IDateTimeElement end);
    ITimeCalculation AddTimeCalculation(string id, ITimeElement start, ITimeElement end);
    ICatalogueItem AddCatalogue(string id, IDataSource dataSource);
    IRatingElement AddRating(string id);
    ISmileyElement AddSmiley(string id);
}

public interface IFormBuilder : IFormContainer
{
    IFormBuilder Tag(string tag);
    IFormBuilder Icon(string icon);
    IFormBuilder InAppDescription(string inAppDesc);
    IFormBuilder Name(string name);
    Task<IFormInfo> BuildAsync(bool removeDrafts = true);
    string GetHash();
    string CreateOpenApiSpec();
    IFormBuilder Description(string desc);
    IFormBuilder AddToGroup(IGroup group);
    IFormBuilder FolderPosition(int position);
    
}

public interface IMultiLangFormBuilder : IFormContainer, IMultiLangFormContainer
{
    IMultiLangFormBuilder Name(string name);
    IMultiLangFormBuilder Tag(string tag);
    IMultiLangFormBuilder Icon(string icon);
    IMultiLangFormBuilder InAppDescription(string inAppDesc);
    Task<IFormInfo> BuildAsync(bool removeDrafts = true);
    string GetHash();
    string CreateOpenApiSpec();
    IMultiLangFormBuilder AddToGroup(IGroup group);
    IMultiLangFormBuilder FolderPosition(int position);
    public string Language { get; }
}



public interface IFormInfo
{
    string Id { get; }
    string Name { get; }
    string Label { get; }
    IReadOnlyCollection<string> Tags { get; }
}