namespace MoreAppBuilder;

public interface ISearchElement : IInputField<ISearchElement>
{
    ISearchElement VisibleFields(params string[] fields);
    ISearchElement FilterUserName();
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

public interface IReadOnlyText : IInputElement<IReadOnlyText>
{
    IReadOnlyText ShowHeader();
    IReadOnlyText SetValueWhen(string value, params ICondition[] conditions);
    IReadOnlyText SetValueWhenAny(string value, params ICondition[] conditions);
}