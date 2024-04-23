﻿using System.Security.Cryptography;
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

    internal VisibilityRule? Rule { get; set; } = null;
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

    internal virtual string HashValue() => Hash(Field.Widget, JsonConvert.SerializeObject(Field.Properties), Rule?.HashValue());
}

internal class Element<T> : Element, IElement<T> where T : class
{
    protected Element(string widgetType) : base(widgetType)
    {
    }
    public T EnabledWhen(params ICondition[] conditions)
    {
        Rule = new VisibilityRule(conditions, true);
        return this as T;
    }

    public T EnabledWhenAny(params ICondition[] conditions)
    {
        Rule = new VisibilityRule(conditions, true, true);
        return this as T;
    }

    public T DisableWhen(params ICondition[] conditions)
    {
        Rule = new VisibilityRule(conditions, false, false);
        return this as T;
    }

    public T DisableWhenAny(params ICondition[] conditions)
    {
        Rule = new VisibilityRule(conditions, false, true);
        return this as T;
    }

    public virtual ICondition ValueIs(string value) => ValueIs((JToken)value);

    public virtual ICondition ValueIs(JToken value)
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