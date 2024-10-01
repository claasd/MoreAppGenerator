using MoreAppBuilder.Implementation.Model.Forms;

namespace MoreAppBuilder.Implementation;

internal class ReadOnlyTextElement : DataElement<IReadOnlyText>, IReadOnlyText
{
    internal override List<RuleBase> Rules => GetAllRules();

    private List<RuleBase> GetAllRules()
    {
        var rules = base.Rules;
        rules.AddRange(SetValueRules.Values);
        return rules;
    }

    Dictionary<string, SetValueRule> SetValueRules { get; set; } = new();

    public ReadOnlyTextElement(string id, string label) : base("nl.gildesoftware:readonlytext:6", id, label, false)
    {
        Field.Properties["showheader"] = false;
    }

    public IReadOnlyText ShowHeader()
    {
        Field.Properties["showheader"] = true;
        return this;
    }

    public IReadOnlyText SetValueWhen(string value, params ICondition[] conditions)
    {
        if (conditions.Any())
            SetValueRules[$"all/{value}"] = new SetValueRule(conditions, value, false);
        return this;
    }

    public IReadOnlyText SetValueWhenAny(string value, params ICondition[] conditions)
    {
        if (conditions.Any())
            SetValueRules[$"any/{value}"] = new SetValueRule(conditions, value, false);
        return this;
    }
}

internal class SetValueRule : RuleBase
{
    public ICondition[] Conditions { get; }
    public string Value { get; }
    public bool IsAny { get; }

    public SetValueRule(ICondition[] conditions, string value, bool isAny)
    {
        Conditions = conditions;
        Value = value;
        IsAny = isAny;
    }

    internal override Rule ToRule(string fieldUid, string fieldName)
    {
        return new Rule()
        {
            Name = $"setValue {fieldName}",
            Conditions = Conditions.Select(ToCondition).ToList(),
            Type = IsAny ? Rule.TypeValue.OR : Rule.TypeValue.AND,
            Actions = new List<Model.Forms.Action>()
            {
                new()
                {
                    FieldUid = fieldUid,
                    Key = "value",
                    Value = Value,
                }
            }
        };
    }
}