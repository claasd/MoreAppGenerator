namespace MoreAppBuilder.Implementation;

public interface IImageElement : IElement<IImageElement>
{
    IImageElement ClickToView();
    IImageElement SetMaxSize(int width, int height);
}