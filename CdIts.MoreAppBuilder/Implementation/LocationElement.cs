namespace MoreAppBuilder.Implementation;

internal class LocationElement : InputElement<ILocation>, ILocation
{
    internal LocationElement(string id, string label) : base("com.moreapps:location:1", id, label)
    {
        Field.Properties["initial_current_location"] = false;
    }

    public ILocation InitialCurrentLocation()
    {
        Field.Properties["initial_current_location"] = true;
        return this;
    }
}