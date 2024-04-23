namespace MoreAppBuilder;

public interface IBarcodeScannerElement : IRememberableValueField<IBarcodeScannerElement>;
public interface IEmailElement : IValueFieldWithPlaceholder<IEmailElement>, IWithDefault<IEmailElement>;
public interface IPhoneElement : IValueFieldWithPlaceholder<IPhoneElement>, IWithDefault<IPhoneElement>;
public interface IDateElement : IRememberableValueField<IDateElement>, IWithNowAsDefault<IDateElement>;
public interface ITimeElement : IRememberableValueField<ITimeElement>, IWithNowAsDefault<ITimeElement>;
public interface IDateTimeElement : IRememberableValueField<IDateTimeElement>, IWithNowAsDefault<IDateTimeElement>;

public interface INumberElement : IValueFieldWithPlaceholder<INumberElement>
{
    INumberElement Minimum(int min);
    INumberElement Maximum(int max);
}
public interface ILookupElement : IRememberableValueField<ILookupElement>
{
    ILookupElement AddOption(string id, string desc, bool isDefault = false);
    ILookupElement MultiSelection();
    ILookupElement AddOptions(IEnumerable<KeyValuePair<string, string>> options);
}

public interface IRadioElement : IRememberableValueField<IRadioElement>
{
    IRadioElement AddOption(string id, string desc, bool isDefault = false);
    IRadioElement VerticalAlignment();
    IRadioElement AddOptions(IEnumerable<KeyValuePair<string, string>> options);
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

public interface ISliderElement : IRememberableValueField<ISliderElement>
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