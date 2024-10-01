using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json;

namespace MoreAppBuilder.Implementation;

abstract class RuleBase
{
    internal abstract Rule ToRule(string fieldUid, string fieldName);
    protected Condition ToCondition(ICondition arg)
    {
        var info = arg as ConditionInfo;
        return new Condition()
        {
            FieldUid = info.FieldUid,
            Key = info.Key,
            Type = info.Type,
            Value = info.Value,
            FieldObjectKey = info.FieldObjectKey
        };
    }

    internal string HashValue()
    {
        var hash = JsonConvert.SerializeObject(this);
        return hash;
    }
}