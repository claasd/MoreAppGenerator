namespace MoreAppBuilder.Implementation;

internal class SliderElement : InputElement<ISliderElement>, ISliderElement
{
    public SliderElement(string id, string label) : base("com.moreapps:slider:1", id, label)
    {
        Field.Properties["min"] = 0;
        Field.Properties["max"] = 10;
        Field.Properties["step"] = 1;
        Field.Properties["default_value"] = 0;
        Field.Properties["hide_value"] = false;
    }

    public ISliderElement MinValue(int minValue)
    {
        Field.Properties["min"] = minValue;
        return this;
    }

    public ISliderElement DefaultValue(int value)
    {
        Field.Properties["default_value"] = value;
        return this;
    }

    public ISliderElement MaxValue(int maxValue)
    {
        Field.Properties["max"] = maxValue;
        return this;
    }

    public ISliderElement Step(int step)
    {
        Field.Properties["step"] = step;
        return this;
    }

    public ISliderElement HideValue()
    {
        Field.Properties["hide_value"] = true;
        return this;
    }
}