namespace MoreAppBuilder;

public class MoreAppGroupingResult(params IMoreAppElement[] elements) : MoreAppGroupingResultBase(elements), IElement<MoreAppGroupingResult>
{
    public ICondition[] GroupFinishedConditions { get; init; } = [];

    public new MoreAppGroupingResult EnabledWhen(params ICondition[] conditions)
    {
        base.EnabledWhen(conditions);
        return this;
    }

    public new MoreAppGroupingResult EnabledWhenAny(params ICondition[] conditions)
    {
        base.EnabledWhenAny(conditions);
        return this;
    }

    public new MoreAppGroupingResult DisableWhen(params ICondition[] conditions)
    {
        base.DisableWhen(conditions);
        return this;
    }

    public new MoreAppGroupingResult DisableWhenAny(params ICondition[] conditions)
    {
        base.DisableWhenAny(conditions);
        return this;
    }
}

public class MoreAppGroupingResultBase : IMoreAppElement {
    private readonly IMoreAppElement[] _elements;

    public event EventHandler<ICondition[]>? OnEnableWhen;
    public event EventHandler<ICondition[]>? OnEnableWhenAny;
    public event EventHandler<ICondition[]>? OnDisableWhen;
    public event EventHandler<ICondition[]>? OnDisableWhenAny;
    
    protected MoreAppGroupingResultBase(params IMoreAppElement[] elements)
    {
        _elements = elements;
    }

    public void EnabledWhen(params ICondition[] conditions)
    {
        foreach (var element in _elements)
        {
            element.EnabledWhen(conditions);
        }
        OnEnableWhen?.Invoke(this, conditions);
    }

    public void EnabledWhenAny(params ICondition[] conditions)
    {
        foreach (var element in _elements)
        {
            element.EnabledWhenAny(conditions);
        }
        OnEnableWhenAny?.Invoke(this, conditions);
    }

    public void DisableWhen(params ICondition[] conditions)
    {
        foreach (var element in _elements)
        {
            element.DisableWhen(conditions);
        }
        OnDisableWhen?.Invoke(this, conditions);
    }

    public void DisableWhenAny(params ICondition[] conditions)
    {
        foreach (var element in _elements)
        {
            element.DisableWhenAny(conditions);
        }
        OnDisableWhenAny?.Invoke(this, conditions);   
    }
}