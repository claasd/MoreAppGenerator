using System.Security.Cryptography;
using System.Text;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

internal class Element
{
    internal protected static string Hash(params string?[] data) => Convert
        .ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(string.Join("|", data.Where(d => d is not null))))).Replace("-", "").ToLower();

    internal virtual void Consolidate()
    {
    }

    internal virtual List<RuleBase> Rules => Rule is null ? [] : [Rule];
    protected VisibilityRule? Rule { get; set; } = null;

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
}

internal class Element<T> : Element, IElement<T> where T : class
{
    protected Element(string widgetType) : base(widgetType)
    {
    }

    internal override List<RuleBase> Rules => GetAllRules();

    private List<RuleBase> GetAllRules()
    {
        var rules = base.Rules;
        rules.AddRange(SetValueRules.Values);
        return rules;
    }

    Dictionary<string, SetValueRule> SetValueRules { get; set; } = new();

    public T EnabledWhen(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rule = new VisibilityRule(conditions, true);
        return this as T;
    }

    public T DisableWhen(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rule = new VisibilityRule(conditions, false, false);
        return this as T;
    }

    public T DisableWhenAny(params ICondition[] conditions)
    {
        if (conditions.Any())
            Rule = new VisibilityRule(conditions, false, true);
        return this as T;
    }

    public T SetValueWhenAny(string value, params ICondition[] conditions)
    {
        if (conditions.Any())
            SetValueRules[$"any/{value}"] = new SetValueRule(conditions, value, false);
        return this as T;
    }

    public T SetValueWhen(string value, params ICondition[] conditions)
    {
        if (conditions.Any())
            SetValueRules[$"all/{value}"] = new SetValueRule(conditions, value, false);
        return this as T;
    }


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