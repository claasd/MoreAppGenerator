﻿using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

internal class SubFormElement : SubFormContainer<ISubFormElement>, ISubFormElement
{
    public SubFormElement(string id, string label) : base(id, label)
    {
    }
}

internal class MultiLangSubFormElement : SubFormContainer<IMultiLangSubFormElement>, IMultiLangSubFormElement
{
    private readonly MoreAppMultiLangData _languageData;

    public MultiLangSubFormElement(string id, MoreAppLanguageInstance languageFile, string parentForm) : base(id, languageFile.Get(parentForm, id))
    {
        _languageData = new MoreAppMultiLangData(this, languageFile, parentForm, id);
        try
        {
            AddButtonText(languageFile.Get(parentForm, id, ".button"));
        }
        catch (KeyNotFoundException) { /* okay */}
        try
        {
            ItemDescription(languageFile.Get(parentForm, id, ".desc"));
        }
        catch (KeyNotFoundException) { /* okay */}
    }

    public IHtmlElement AddHtmlById(string id) => _languageData.AddHtmlById(id);
    public IHtmlElement AddHtmlSectionById(string id, HeaderElementSize size = HeaderElementSize.H3) => _languageData.AddHtmlSectionById(id, size);
    public ILabelElement AddLabelById(string id) => _languageData.AddLabelById(id);
    public IHeaderElement AddHeaderById(string id, HeaderElementSize size = HeaderElementSize.H2) => _languageData.AddHeaderById(id, size);
    public ILookupElement AddLookup(string id) => _languageData.AddLookup(id);
    public IRadioElement AddRadio(string id) => _languageData.AddRadio(id);
    public ISignatureElement AddSignature(string id) => _languageData.AddSignature(id);
    public ISliderElement AddSlider(string id) => _languageData.AddSlider(id);
    public ISearchElement AddSearch(string id, IDataSource dataSource) => _languageData.AddSearch(id, dataSource);
    public IPhotoElement AddPhoto(string id) => _languageData.AddPhoto(id);
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
    public IMultiLangSubFormElement AddSubForm(string id) => _languageData.AddSubForm(id);
    public IDrawingElement AddDrawing(string id) => _languageData.AddDrawing(id);
}