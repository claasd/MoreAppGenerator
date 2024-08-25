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
    private string Data(string name, bool allowGlobal = true) => _languageFile.GetTitle(_formId, WithPrefix(name), allowGlobal);
    private string Desc(string name, bool allowGlobal = true) => _languageFile.GetDesc(_formId, WithPrefix(name), allowGlobal);

    public IHtmlElement AddHtmlById(string id) => _builder.AddHtml(Data(id));
    public IHtmlElement AddHtmlSectionById(string id, HeaderElementSize size = HeaderElementSize.H3)
    {
        var title = Data(id);
        var lines = Desc(id).Split("\n");
        return _builder.AddHtmlSection(title, size, lines);
    }

    public ILabelElement AddLabelById(string id) => _builder.AddLabel(Data(id));
    public IHeaderElement AddHeaderById(string id, HeaderElementSize size = HeaderElementSize.H2) => _builder.AddHeader(Data(id), size);
    public ILookupElement AddLookup(string id) => _builder.AddLookup(id, Data(id));
    public IRadioElement AddRadio(string id) => _builder.AddRadio(id, Data(id));
    public ISignatureElement AddSignature(string id) => _builder.AddSignature(id, Data(id));
    public ISliderElement AddSlider(string id) => _builder.AddSlider(id, Data(id));
    public ISearchElement AddSearch(string id, IDataSource dataSource) => _builder.AddSearch(id, Data(id), dataSource);
    public IPhotoElement AddPhoto(string id) => _builder.AddPhoto(id, Data(id));
    public IBarcodeScannerElement AddBarcodeScanner(string id) => _builder.AddBarcodeScanner(id, Data(id));
    public ICheckboxItem AddCheckbox(string id) => _builder.AddCheckbox(id, Data(id));
    public IDateElement AddDate(string id) => _builder.AddDate(id, Data(id));
    public ITimeElement AddTime(string id) => _builder.AddTime(id, Data(id));
    public IDateTimeElement AddDateTime(string id) => _builder.AddDateTime(id, Data(id));
    public IEmailElement AddEmail(string id) => _builder.AddEmail(id, Data(id));
    public INumberElement AddNumber(string id) => _builder.AddNumber(id, Data(id));
    public IPhoneElement AddPhone(string id) => _builder.AddPhone(id, Data(id));
    public ITextElement AddText(string id) => _builder.AddText(id, Data(id));
    public ITextAreaElement AddTextArea(string id) => _builder.AddTextArea(id, Data(id));
    public IMultiLangSubFormElement AddSubForm(string id) => _builder.AddElement(new MultiLangSubFormElement(id, _languageFile, _formId));

    public IDrawingElement AddDrawing(string id) => _builder.AddDrawing(id, Data(id));
    public string FormName() => Data("__title", false);
    
}