namespace MoreAppBuilder;

public interface ISearchElement : IInputField<ISearchElement>
{
    ISearchElement VisibleFields(params string[] fields);
    ISearchElement FilterUserName();
    ISearchElement Filter<T>(IStringValueField<T> element);
    ISearchElement Filter(ISearchElement element, string field);
    ISearchElement AllowBarcodeScanner();
    ISearchElement RememberLastSearch();
    ICondition FieldHasValue(string field);
    ICondition FieldHasNoValue(string field);
    ICondition FieldHasExactValue(string field, string value);
}

public interface IDrawingElement : IValueField<IDrawingElement>
{
}

public interface ILocation : IValueField<ILocation>, IRememberable<ILocation>
{
    ILocation InitialCurrentLocation();
}

public interface IReadOnlyText : IInputElement<IReadOnlyText>, IStringValueOperations<IReadOnlyText>
{
    IReadOnlyText ShowHeader();
}

public interface IFileElement : IValueField<IFileElement>
{
    IFileElement ForDocuments();
    IFileElement ForImages();
    IFileElement ForAudio();
    IFileElement ForVideo();
}

public interface ITimeCalculation : IValueField<ITimeCalculation>;

public interface ICatalogueItem : IInputField<ICatalogueItem>
{
    ICatalogueItem SetCurrency(string currency);
    ICatalogueItem SetVatRate(double vatRate);
    ICatalogueItem ShowPrices();
    ICatalogueItem ShowVat();
    ICatalogueItem AllowRemarks();
    ICatalogueItem UseBarcodeScanner();
}