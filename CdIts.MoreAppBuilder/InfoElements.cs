namespace MoreAppBuilder;

public interface IHeaderElement : IElement<IHeaderElement>;
public interface IHtmlElement : IElement<IHtmlElement>;
public interface ILabelElement : IElement<ILabelElement>;
public enum HeaderElementSize
{
    H1,
    H2,
    H3,
    H4,
    H5,
    H6
}