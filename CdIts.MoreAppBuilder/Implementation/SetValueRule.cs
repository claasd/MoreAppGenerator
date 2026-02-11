using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

internal class SetValueRule : RuleBase
{
    public ICondition[] Conditions { get; }
    public JToken Value { get; }
    public bool IsAny { get; }

    public SetValueRule(ICondition[] conditions, JToken value, bool isAny)
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