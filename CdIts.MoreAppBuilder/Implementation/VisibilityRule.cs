using System.Security.Cryptography;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;
using Action = System.Action;

namespace MoreAppBuilder.Implementation;

internal class VisibilityRule : RuleBase
{
    public ICondition[] Conditions { get;  }
    public bool IsVisible { get; }
    public bool IsAny { get; }

    internal VisibilityRule(ICondition[] conditions, bool isVisible, bool isAny = false)
    {
        Conditions = conditions;
        IsVisible = isVisible;
        IsAny = isAny;
    }

    internal override Rule ToRule(string fieldUid, string fieldName)
    {
        return new Rule()
        {
            Name = $"visibility {fieldName}",
            Conditions = Conditions.Select(ToCondition).ToList(),
            Type = IsAny ? Rule.TypeValue.OR : Rule.TypeValue.AND,
            Actions = new List<Model.Forms.Action>()
            {
                new()
                {
                    FieldUid = fieldUid,
                    Key = "visible",
                    Value = IsVisible,
                }
            }
        };
    }
}