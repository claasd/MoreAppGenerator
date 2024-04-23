namespace MoreAppBuilder.Implementation;

internal class CheckboxItem : DataElement<ICheckboxItem>, ICheckboxItem
{
    public CheckboxItem(string id, string label) : base("com.moreapps:checkbox:1", id, label)
    {
        Field.Properties["checkbox_default_value"] = false;
    }

    

    public ICheckboxItem CheckedAsDefault()
    {
        Field.Properties["checkbox_default_value"] = true;
        return this;
    }

    public ICondition IsChecked() => ValueIs(true);
    public ICondition IsNotChecked() => ValueIs(false);
    
}