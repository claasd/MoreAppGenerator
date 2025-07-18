﻿namespace MoreAppBuilder.Implementation;

internal class MultiLangFormBuilder : FormBuilder, IMultiLangFormBuilder
{
    private readonly MoreAppMultiLangData _languageData;

    internal MultiLangFormBuilder(RestClient client, IMoreAppCaching caching, MoreAppLanguageInstance languageData, string id, string langId, IFolder? folder = null) 
        : base(client, caching, id, languageData.FormName(langId), folder: folder)
    {
        Language = languageData.Language;
        _languageData = new MoreAppMultiLangData(this, languageData, langId);
        try
        {
            Description(languageData.FormDesc(langId));
        } catch(KeyNotFoundException) { /*okay */ }
    }
    public string Language { get; }
    public IHtmlElement AddHtmlById(string id) => _languageData.AddHtmlById(id);
    public IHtmlElement AddHtmlSectionById(string id, HeaderElementSize size = HeaderElementSize.H3) => _languageData.AddHtmlSectionById(id, size);
    public IHtmlElement AddCardById(CardType type, string id) => _languageData.AddCardById(type, id);

    public ILabelElement AddLabelById(string id) => _languageData.AddLabelById(id);
    public IHeaderElement AddHeaderById(string id, HeaderElementSize size = HeaderElementSize.H2) => _languageData.AddHeaderById(id, size);
    public IMultiLangLookupElement AddLookup(string id) => _languageData.AddLookup(id);
    public IMultiLangRadioElement AddRadio(string id) => _languageData.AddRadio(id);
    public ISignatureElement AddSignature(string id) => _languageData.AddSignature(id);
    public ISliderElement AddSlider(string id) => _languageData.AddSlider(id);
    public ISearchElement AddSearch(string id, IDataSource dataSource) => _languageData.AddSearch(id, dataSource);
    public IPhotoElement AddPhoto(string id) => _languageData.AddPhoto(id);
    public IFileElement AddFile(string id) => _languageData.AddFile(id);
    public IBarcodeScannerElement AddBarcodeScanner(string id) => _languageData.AddBarcodeScanner(id);
    public ICheckboxItem AddCheckbox(string id) => _languageData.AddCheckbox(id);
    public IDateElement AddDate(string id)  => _languageData.AddDate(id);
    public ITimeElement AddTime(string id) => _languageData.AddTime(id);
    public IDateTimeElement AddDateTime(string id) => _languageData.AddDateTime(id);
    public IEmailElement AddEmail(string id) => _languageData.AddEmail(id);
    public INumberElement AddNumber(string id)  => _languageData.AddNumber(id);
    public IPhoneElement AddPhone(string id) => _languageData.AddPhone(id);
    public ITextElement AddText(string id) => _languageData.AddText(id);
    public ITextAreaElement AddTextArea(string id)  => _languageData.AddTextArea(id);
    public IMultiLangSubFormElement AddSubForm(string id, LangPrefixMode prefixMode = LangPrefixMode.FullPrefix) => _languageData.AddSubForm(id, prefixMode);
    public IDrawingElement AddDrawing(string id) => _languageData.AddDrawing(id);
    public ILocation AddLocation(string id) => _languageData.AddLocation(id);
    public IReadOnlyText AddReadOnlyText(string id) => _languageData.AddReadOnlyText(id);
    public ITimeCalculation AddTimeCalculation(string id, IDateTimeElement start, IDateTimeElement end) => _languageData.AddTimeCalculation(id, start, end);
    public ITimeCalculation AddTimeCalculation(string id, ITimeElement start, ITimeElement end) => _languageData.AddTimeCalculation(id, start, end);
    public ICatalogueItem AddCatalogue(string id, IDataSource dataSource) => _languageData.AddCatalogue(id, dataSource);
    public IRatingElement AddRating(string id) => _languageData.AddRating(id);

    public ISmileyElement AddSmiley(string id) => _languageData.AddSmiley(id);
    public string GetTitleForCurrentLanguage(string fieldName) => _languageData.GetTitleForCurrentLanguage(fieldName);

    public string GetDescForCurrentLanguage(string fieldName) => _languageData.GetDescForCurrentLanguage(fieldName);

    public string GetOptionForCurrentLanguage(string fieldName, string option) => _languageData.GetOptionForCurrentLanguage(fieldName, option);
    public new IMultiLangFormBuilder Name(string name)
    {
        base.Name(name);
        return this;
    }

    public new IMultiLangFormBuilder Tag(string tag)
    {
        base.Tag(tag);
        return this;
    }
    
    public new IMultiLangFormBuilder Icon(string icon)
    {
        base.Icon(icon);
        return this;
    }

    public IMultiLangFormBuilder InAppDescription(string inAppDesc)
    {
        base.InAppDescription(inAppDesc);
        return this;
    }

    public new IMultiLangFormBuilder AddToGroup(IGroup group)
    {
        base.AddToGroup(group);
        return this;
    }

    public new IMultiLangFormBuilder FolderPosition(int position)
    {
        base.FolderPosition(position);
        return this;
    }

    
}