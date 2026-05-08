using System.Security.Cryptography;
using System.Text;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

internal class Element : IMoreAppElement
{
    internal static string Hash(params string?[] data) => Convert
        .ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("|", data.Where(d => d is not null))))).Replace("-", "").ToLower();

    internal virtual void Consolidate()
    {
    }

    internal virtual List<RuleBase> Rules { get; } = [];

    internal Field Field { get; }

    protected Element(string widgetType)
    {
        Field = new Field()
        {
            Uid = Guid.NewGuid().ToString("N")[..24],
            Widget = widgetType,
            Properties = new Dictionary<string, object>()
        };
    }

    internal virtual string HashValue() => Hash(Field.Widget, JsonConvert.SerializeObject(Field.Properties), JsonConvert.SerializeObject(Rules));
    public void EnabledWhen(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rules.Add(new VisibilityRule(conditions, true));
    }

    public void EnabledWhenAny(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rules.Add(new VisibilityRule(conditions, true, isAny: true));
    }

    public void DisableWhen(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rules.Add(new VisibilityRule(conditions, false));
    }

    public void DisableWhenAny(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rules.Add(new VisibilityRule(conditions, false, true));
    }
}

internal class Element<T> : Element, IElement<T> where T : class
{
    protected Element(string widgetType) : base(widgetType)
    {
    }


    public new T EnabledWhen(params ICondition[] conditions)
    {
        base.EnabledWhen(conditions);
        return this as T;
    }
    public new T EnabledWhenAny(params ICondition[] conditions)
    {
        base.EnabledWhenAny(conditions);
        return this as T;
    }

    public new T DisableWhen(params ICondition[] conditions)
    {
        base.DisableWhen(conditions);
        return this as T;
    }

    public new T DisableWhenAny(params ICondition[] conditions)
    {
        base.DisableWhenAny(conditions);
        return this as T;
    }

    protected T SetValue(JToken value, ICondition[] conditions, bool isAnyRule)
    {
        if (conditions.Any())
            Rules.Add(new SetValueRule(conditions, value, isAnyRule));
        return this as T;
    }

    public T SetValueWhenAny(string value, params ICondition[] conditions) => SetValue(value, conditions, true);

    public T SetValueWhen(string value, params ICondition[] conditions)=> SetValue(value, conditions, false);


    public ICondition GreaterThan(int value)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD,
            Key = "greaterThan",
            Value = value,
            FieldUid = Field.Uid
        };
    }

    public ICondition LessThan(int value)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD,
            Key = "lessThan",
            Value = value,
            FieldUid = Field.Uid
        };
    }

    public virtual ICondition ValueIs(string value) => ValueIs((JToken)value);
    public virtual ICondition ValueIs(int value) => ValueIs((JToken)value);

    public ICondition ValueIs(JToken value)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD,
            Key = "is",
            Value = value,
            FieldUid = Field.Uid
        };
    }
    
    public ICondition ValueContains(string value)
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD,
            Key = "contains",
            Value = value,
            FieldUid = Field.Uid
        };
    }

    public virtual ICondition HasValue()
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD,
            Key = "hasValue",
            Value = true,
            FieldUid = Field.Uid
        };
    }

    public virtual ICondition HasNoValue()
    {
        return new ConditionInfo()
        {
            Type = Condition.TypeValue.FIELD,
            Key = "hasValue",
            Value = false,
            FieldUid = Field.Uid
        };
    }
}