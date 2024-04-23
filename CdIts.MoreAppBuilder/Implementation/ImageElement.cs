namespace MoreAppBuilder.Implementation;

internal class ImageElement : Element<IImageElement>, IImageElement
{
    internal ImageElement(string resourceId) : base("com.moreapps:image:1")
    {
        Field.Properties["click_to_view"] = false;
        Field.Properties["resource_id"] = resourceId;
    }

    public IImageElement ClickToView()
    {
        Field.Properties["click_to_view"] = true;
        return this;
    }

    public IImageElement SetMaxSize(int width, int height)
    {
        Field.Properties["max_width"] = width;
        Field.Properties["max_height"] = height;
        return this;
    }
}