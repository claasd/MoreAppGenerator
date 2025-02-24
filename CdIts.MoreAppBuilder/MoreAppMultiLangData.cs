using MoreAppBuilder.Implementation;

namespace MoreAppBuilder;

internal class MoreAppMultiLangData : IMultiLangFormContainer
{
    private readonly IGenericFormContainer _builder;
    private readonly MoreAppLanguageInstance _languageFile;
    private readonly string _formId;
    private readonly string? _fieldPrefix;

    internal MoreAppMultiLangData(IGenericFormContainer builder, MoreAppLanguageInstance languageFile, string formId, string? fieldPrefix = null) 
    {
        _builder = builder;
        _languageFile = languageFile;
        _formId = formId;
        _fieldPrefix = fieldPrefix;
    }

    private string WithPrefix(string name) => _fieldPrefix is null ? name : $"{_fieldPrefix}.{name}";
    private string Title(string name, bool allowGlobal = true) => _languageFile.GetTitle(_formId, WithPrefix(name), allowGlobal);
    private string Desc(string name, bool allowGlobal = true) => _languageFile.GetDesc(_formId, WithPrefix(name), allowGlobal);

    public IHtmlElement AddHtmlById(string id) => _builder.AddHtml(Title(id));
    public IHtmlElement AddHtmlSectionById(string id, HeaderElementSize size = HeaderElementSize.H3)
    {
        var title = Title(id);
        var lines = Desc(id).Split("\n");
        return _builder.AddHtmlSection(title, size, lines);
    }

    public ILabelElement AddLabelById(string id) => _builder.AddLabel(Title(id));
    public IHeaderElement AddHeaderById(string id, HeaderElementSize size = HeaderElementSize.H2) => _builder.AddHeader(Title(id), size);
    public IMultiLangLookupElement AddLookup(string id) => _builder.AddElement(new MultiLineLookupElement(id, Title(id), new FieldLangLookup(_languageFile, _formId, WithPrefix(id))));
    public IMultiLangRadioElement AddRadio(string id) => _builder.AddElement(new MultiLangRadioElement(id, Title(id), new FieldLangLookup(_languageFile, _formId, WithPrefix(id))));
    public ISignatureElement AddSignature(string id) => _builder.AddSignature(id, Title(id));
    public ISliderElement AddSlider(string id) => _builder.AddSlider(id, Title(id));
    public ISearchElement AddSearch(string id, IDataSource dataSource) => _builder.AddSearch(id, Title(id), dataSource);
    public IPhotoElement AddPhoto(string id) => _builder.AddPhoto(id, Title(id));
    public IFileElement AddFile(string id) => _builder.AddFile(id, Title(id));
    public IBarcodeScannerElement AddBarcodeScanner(string id) => _builder.AddBarcodeScanner(id, Title(id));
    public ICheckboxItem AddCheckbox(string id) => _builder.AddCheckbox(id, Title(id));
    public IDateElement AddDate(string id) => _builder.AddDate(id, Title(id));
    public ITimeElement AddTime(string id) => _builder.AddTime(id, Title(id));
    public IDateTimeElement AddDateTime(string id) => _builder.AddDateTime(id, Title(id));
    public IEmailElement AddEmail(string id) => _builder.AddEmail(id, Title(id));
    public INumberElement AddNumber(string id) => _builder.AddNumber(id, Title(id));
    public IPhoneElement AddPhone(string id) => _builder.AddPhone(id, Title(id));
    public ITextElement AddText(string id) => _builder.AddText(id, Title(id));
    public ITextAreaElement AddTextArea(string id) => _builder.AddTextArea(id, Title(id));
    public IMultiLangSubFormElement AddSubForm(string id) => _builder.AddElement(new MultiLangSubFormElement(id, _languageFile, _formId, WithPrefix(id)));

    public IDrawingElement AddDrawing(string id) => _builder.AddDrawing(id, Title(id));
    public ILocation AddLocation(string id) => _builder.AddLocation(id, Title(id));
    public IReadOnlyText AddReadOnlyText(string id) => _builder.AddReadOnlyText(id, Title(id));
    public ITimeCalculation AddTimeCalculation(string id, IDateTimeElement start, IDateTimeElement end) => _builder.AddTimeCalculation(id, Title(id), start, end);
    public ITimeCalculation AddTimeCalculation(string id, ITimeElement start, ITimeElement end) => _builder.AddTimeCalculation(id, Title(id), start, end);
    public ICatalogueItem AddCatalogue(string id, IDataSource dataSource) => _builder.AddCatalogue(id, Title(id), dataSource);
    public IRatingElement AddRating(string id) => _builder.AddRating(id, Title(id));
    public ISmileyElement AddSmiley(string id) => _builder.AddSmiley(id, Title(id));

    public string FormName() => Title("__title", false);
    
}