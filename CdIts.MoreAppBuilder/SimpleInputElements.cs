namespace MoreAppBuilder;

public interface IBarcodeScannerElement : IStringValueField<IBarcodeScannerElement>;
public interface IEmailElement : IValueFieldWithPlaceholder<IEmailElement>, IWithDefault<IEmailElement>;
public interface IPhoneElement : IValueFieldWithPlaceholder<IPhoneElement>, IWithDefault<IPhoneElement>;
public interface IDateElement : IStringValueField<IDateElement>, IWithNowAsDefault<IDateElement>;
public interface ITimeElement : IStringValueField<ITimeElement>, IWithNowAsDefault<ITimeElement>;
public interface IDateTimeElement : IStringValueField<IDateTimeElement>, IWithNowAsDefault<IDateTimeElement>;

public interface INumberElement : IValueFieldWithPlaceholder<INumberElement>, INumericValueField
{
    INumberElement Minimum(int min);
    INumberElement Maximum(int max);
}
public interface ILookupElement : IStringValueField<ILookupElement>
{
    ILookupElement AddOption(string id, string desc, bool isDefault = false);
    ILookupElement MultiSelection();
    ILookupElement AddOptions(IEnumerable<KeyValuePair<string, string>> options);
    ILookupElement AddRange(int first, int last);
}

public interface IMultiLangLookupElement : IStringValueField<IMultiLangLookupElement>
{
    IMultiLangLookupElement AddOption(string id, string desc, bool isDefault = false);
    IMultiLangLookupElement AddOption(string id, bool isDefault = false, string? globalConfigSection = null);
    IMultiLangLookupElement AddOptions(IEnumerable<KeyValuePair<string, string>> options);
    IMultiLangLookupElement MultiSelection();
    IMultiLangLookupElement AddRange(int first, int last, string? globalConfigSection = null);
}

public interface IRadioElement : IStringValueField<IRadioElement>
{
    IRadioElement AddOption(string id, string desc, bool isDefault = false);
    IRadioElement VerticalAlignment();
    IRadioElement AddOptions(IEnumerable<KeyValuePair<string, string>> options);
}

public interface IMultiLangRadioElement : IStringValueField<IMultiLangRadioElement>
{
    IMultiLangRadioElement AddOption(string id, string desc, bool isDefault = false);
    IMultiLangRadioElement AddOption(string id, bool isDefault = false, string? globalConfigSection = null, string? fallbackValue = null);
    IMultiLangRadioElement VerticalAlignment();
    IMultiLangRadioElement AddOptions(IEnumerable<KeyValuePair<string, string>> options);
}

public interface ICheckboxItem : IInputElement<ICheckboxItem>
{
    ICheckboxItem CheckedAsDefault();
    ICondition IsChecked();
    ICondition IsNotChecked();
    ICondition HasValue();
    ICondition HasNoValue();
}

public interface IPhotoElement : IValueField<IPhotoElement>
{
    IPhotoElement BestQuality();
    IPhotoElement HighQuality();
    IPhotoElement FastUploadQuality();
    IPhotoElement AllowDeviceSelection();
}

public interface ITextElement : IValueFieldWithPlaceholder<ITextElement>, IWithDefault<ITextElement>
{
    ITextElement MinLength(int minLength);
    ITextElement MaxLength(int minLength);
}

public interface ITextAreaElement : IValueFieldWithPlaceholder<ITextAreaElement>, IWithDefault<ITextAreaElement>
{
    ITextAreaElement MaxLength(int minLength);
}

public interface ISliderElement : INumericValueField, IStringValueField<ISliderElement> 
{
    ISliderElement MinValue(int minValue);
    ISliderElement DefaultValue(int value);
    ISliderElement MaxValue(int maxValue);
    ISliderElement Step(int step);
    ISliderElement HideValue();
}

public interface ISignatureElement : IValueField<ISignatureElement>
{
    ISignatureElement PenWidth(int penWidth);
    ISignatureElement Wide();
}