namespace MoreAppBuilder.Implementation;

internal class ReadOnlyTextElement : DataElement<IReadOnlyText>, IReadOnlyText
{

    public ReadOnlyTextElement(string id, string label) : base("nl.gildesoftware:readonlytext:6", id, label, false)
    {
        Field.Properties["showheader"] = false;
    }

    public IReadOnlyText ShowHeader()
    {
        Field.Properties["showheader"] = true;
        return this;
    }
}