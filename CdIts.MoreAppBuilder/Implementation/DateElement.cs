using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class DateElement : InputElement<IDateElement>, IDateElement
{
    public DateElement(string id, string label) : base("com.moreapps:date:1", id, label)
    {
        Field.Properties["now_as_default"] = false;
    }

    public IDateElement SetNowAsDefault()
    {
        Field.Properties["now_as_default"] = true;
        return this;
    }
}