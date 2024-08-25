namespace MoreAppBuilder;

public interface ISubformContainer<out T>  : IFormContainer, IInputElement<T>
{
    T Minimum(int i);
    T Maximum(int i);
    T ItemDescription(string desc);
    T AddButtonText(string label);
}
public interface ISubFormElement : ISubformContainer<ISubFormElement> 
{
}

public interface IMultiLangSubFormElement : IMultiLangFormContainer, ISubformContainer<IMultiLangSubFormElement>
{
}
