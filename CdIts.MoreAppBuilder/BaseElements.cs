namespace MoreAppBuilder;

public interface IMoreAppElement
{
    void EnabledWhen(params ICondition[] conditions);
    void EnabledWhenAny(params ICondition[] conditions);
    void DisableWhen(params ICondition[] conditions);
    void DisableWhenAny(params ICondition[] conditions);
}

public interface IElement<out T> : IMoreAppElement
{
    new T EnabledWhen(params ICondition[] conditions);
    new T EnabledWhenAny(params ICondition[] conditions);
    new T DisableWhen(params ICondition[] conditions);
    new T DisableWhenAny(params ICondition[] conditions);
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

public interface IStringValueField<out T> : IValueField<T>, IStringValueOperations<T>, IRememberable<T>
{
}

public interface IStringValueOperations<out T>
{
    ICondition ValueIs(string value);
    ICondition ValueContains(string value);
    T SetValueWhen(string value, params ICondition[] conditions);
    T SetValueWhenAny(string value, params ICondition[] conditions);
}

public interface IValueFieldWithPlaceholder<out T> : IStringValueField<T>
{
    T SetPlaceholder(string? placeholder);
}

public interface IWithDefault<out T>
{
    T SetDefault(string defaultValue);
}
public interface IWithNowAsDefault<out T>
{
    T SetNowAsDefault();
}

public interface INumericValueField 
{
    ICondition ValueIs(int value);
    ICondition GreaterThan(int value);
    ICondition LessThan(int value);
}

public interface ICondition;