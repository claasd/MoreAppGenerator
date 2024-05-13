namespace MoreAppBuilder;

public interface ISearchElement : IInputField<ISearchElement>
{
    ISearchElement VisibleFields(params string[] fields);
    ISearchElement FilterUserName();
    ISearchElement AllowBarcodeScanner();
    ISearchElement RememberLastSearch();
    ICondition FieldHasValue(string field);
    ICondition FieldHasNoValue(string field);
}

public interface IDrawingElement : IValueField<IDrawingElement>
{
}