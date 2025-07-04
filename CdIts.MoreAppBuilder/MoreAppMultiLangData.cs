using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

internal class MoreAppMultiLangData : IMultiLangFormContainer
{
    internal readonly IGenericFormContainer Builder;
    private readonly MoreAppLanguageInstance _languageFile;
    private readonly string _formId;
    private readonly string? _fieldPrefix;

    internal MoreAppMultiLangData(IGenericFormContainer builder, MoreAppLanguageInstance languageFile, string formId, string? fieldPrefix = null)
    {
        Builder = builder;
        _languageFile = languageFile;
        _formId = formId;
        _fieldPrefix = fieldPrefix;
    }

    private string WithPrefix(string name) => _fieldPrefix is null ? name : $"{_fieldPrefix}.{name}";

    private string Title(string name, bool allowGlobal = true) => _languageFile.GetTitle(_formId, WithPrefix(name), allowGlobal);
    private string Desc(string name, bool allowGlobal = true) => _languageFile.GetDesc(_formId, WithPrefix(name), allowGlobal);

    public IHtmlElement AddHtmlById(string id) => Builder.AddHtml(Title(id));

    public IHtmlElement AddHtmlSectionById(string id, HeaderElementSize size = HeaderElementSize.H3)
    {
        var title = Title(id);
        var lines = Desc(id).Split("\n");
        return Builder.AddHtmlSection(title, size, lines);
    }

    public IHtmlElement AddCardById(CardType type, string id)
    {
        var title = Title(id);
        var lines = Desc(id).Split("\n");
        return Builder.AddCard(type, title, lines);
    }

    public ILabelElement AddLabelById(string id) => Builder.AddLabel(Title(id));
    public IHeaderElement AddHeaderById(string id, HeaderElementSize size = HeaderElementSize.H2) => Builder.AddHeader(Title(id), size);

    public IMultiLangLookupElement AddLookup(string id) =>
        Builder.AddElement(new MultiLineLookupElement(id, Title(id), new FieldLangLookup(_languageFile, _formId, WithPrefix(id))));

    public IMultiLangRadioElement AddRadio(string id) => Builder.AddElement(new MultiLangRadioElement(id, Title(id), new FieldLangLookup(_languageFile, _formId, WithPrefix(id))));
    public ISignatureElement AddSignature(string id) => Builder.AddSignature(id, Title(id));
    public ISliderElement AddSlider(string id) => Builder.AddSlider(id, Title(id));
    public ISearchElement AddSearch(string id, IDataSource dataSource) => Builder.AddSearch(id, Title(id), dataSource);
    public IPhotoElement AddPhoto(string id) => Builder.AddPhoto(id, Title(id));
    public IFileElement AddFile(string id) => Builder.AddFile(id, Title(id));
    public IBarcodeScannerElement AddBarcodeScanner(string id) => Builder.AddBarcodeScanner(id, Title(id));
    public ICheckboxItem AddCheckbox(string id) => Builder.AddCheckbox(id, Title(id));
    public IDateElement AddDate(string id) => Builder.AddDate(id, Title(id));
    public ITimeElement AddTime(string id) => Builder.AddTime(id, Title(id));
    public IDateTimeElement AddDateTime(string id) => Builder.AddDateTime(id, Title(id));
    public IEmailElement AddEmail(string id) => Builder.AddEmail(id, Title(id));
    public INumberElement AddNumber(string id) => Builder.AddNumber(id, Title(id));
    public IPhoneElement AddPhone(string id) => Builder.AddPhone(id, Title(id));
    public ITextElement AddText(string id) => Builder.AddText(id, Title(id));
    public ITextAreaElement AddTextArea(string id) => Builder.AddTextArea(id, Title(id));

    public IMultiLangSubFormElement AddSubForm(string id, LangPrefixMode prefixMode) =>
        Builder.AddElement(new MultiLangSubFormElement(id, _languageFile, _formId, WithPrefix(id), prefixMode));

    public IDrawingElement AddDrawing(string id) => Builder.AddDrawing(id, Title(id));
    public ILocation AddLocation(string id) => Builder.AddLocation(id, Title(id));
    public IReadOnlyText AddReadOnlyText(string id) => Builder.AddReadOnlyText(id, Title(id));
    public ITimeCalculation AddTimeCalculation(string id, IDateTimeElement start, IDateTimeElement end) => Builder.AddTimeCalculation(id, Title(id), start, end);
    public ITimeCalculation AddTimeCalculation(string id, ITimeElement start, ITimeElement end) => Builder.AddTimeCalculation(id, Title(id), start, end);
    public ICatalogueItem AddCatalogue(string id, IDataSource dataSource) => Builder.AddCatalogue(id, Title(id), dataSource);
    public IRatingElement AddRating(string id) => Builder.AddRating(id, Title(id));
    public ISmileyElement AddSmiley(string id) => Builder.AddSmiley(id, Title(id));

    public string FormName() => Title("__title", false);
}