namespace MoreAppBuilder;

public interface ISubFormElement : IFormContainer, IInputElement<ISubFormElement>
{
    ISubFormElement Minimum(int i);
    ISubFormElement Maximum(int i);
    ISubFormElement ItemDescription(string desc);
    ISubFormElement AddButtonText(string label);
}