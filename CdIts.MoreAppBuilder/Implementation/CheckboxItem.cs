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
    public ICheckboxItem SetCheckedWhen(params ICondition[] conditions) => SetValue(true, conditions, false);
    

    public ICheckboxItem SetCheckedAnyWhen(params ICondition[] conditions) => SetValue(true, conditions, true);

    public ICheckboxItem SetUncheckedWhen(params ICondition[] conditions) => SetValue(false, conditions, false);

    public ICheckboxItem SetUncheckedAnyWhen(params ICondition[] conditions) => SetValue(false, conditions, true);
}