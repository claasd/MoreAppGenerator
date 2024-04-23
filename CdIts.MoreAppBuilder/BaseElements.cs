namespace MoreAppBuilder;

public interface IElement<out T>
{
    T EnabledWhen(params ICondition[] conditions);
    T EnabledWhenAny(params ICondition[] conditions);
    T DisableWhen(params ICondition[] conditions);
    T DisableWhenAny(params ICondition[] conditions);
}

public interface IInputElement<out T> : IElement<T>
{
    T Id(string identifier);
    T Label(string label);
}

public interface IRememberable<out T>
{
    T Remember();
}

public interface IInputField<out T> : IInputElement<T>
{
    T Required();
}

public interface IValueField<out T> : IInputField<T>
{
    ICondition HasValue();
    ICondition HasNoValue();    
}


public interface IRememberableValueField<out T> : IValueField<T>, IRememberable<T>
{
    ICondition ValueIs(string value);
}

public interface IValueFieldWithPlaceholder<out T> : IRememberableValueField<T>
{
    T SetPlaceholder(string placeholder);
}

public interface IWithDefault<out T>
{
    T SetDefault(string defaultValue);
}
public interface IWithNowAsDefault<out T>
{
    T SetNowAsDefault();
}

public interface ICondition;