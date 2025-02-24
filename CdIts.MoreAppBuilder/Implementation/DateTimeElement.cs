using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class DateTimeElement : InputElement<IDateTimeElement>, IDateTimeElement
{
    public DateTimeElement(string id, string label) : base("com.moreapps:datetime:1", id, label)
    {
        Field.Properties["now_as_default"] = false;
    }

    public IDateTimeElement SetNowAsDefault()
    {
        Field.Properties["now_as_default"] = true;
        return this;
    }
}