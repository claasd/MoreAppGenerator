namespace MoreAppBuilder.Implementation;

internal class DataElement<T> : Element<T>, IInputElement<T>, IRememberable<T> where T : class
{
    protected DataElement(string widgetType, string id, string label, bool useRememberInput = true) : base(widgetType)
    {
        Field.Properties["data_name"] = id.Trim();
        Field.Properties["label_text"] = label.Trim();
        if(useRememberInput)
            Field.Properties["remember_input"] = false;
    }
    
    public T Id(string identifier)
    {
        Field.Properties["data_name"] = identifier.Trim();
        return this as T;
    }

    public T Label(string label)
    {
        Field.Properties["label_text"] = label.Trim();
        return this as T;
    }
    public T Remember()
    {
        Field.Properties["remember_input"] = true;
        return this as T;        
    }
}