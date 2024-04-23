namespace MoreAppBuilder.Implementation;

internal class InputElement<T> : DataElement<T>, IInputField<T> where T : class
{
    protected InputElement(string widgetType,string id, string label, bool useRememberInput = true) : base(widgetType, id, label, useRememberInput)
    {
        Field.Properties["required"] = false;
    }

    public T Required()
    {
        Field.Properties["required"] = true;
        return this as T;
    }
}

internal class InputElementWithPlaceholder<T> : InputElement<T>, IValueFieldWithPlaceholder<T> where T : class
{
    protected InputElementWithPlaceholder(string widgetType, string id, string label, bool useRememberInput = true) : base(widgetType, id, label, useRememberInput)
    {
        Field.Properties["text_placeholder"] = "";
    }

    public T SetPlaceholder(string placeholder)
    {
        Field.Properties["text_placeholder"] = placeholder;
        return this as T;
    }
}
