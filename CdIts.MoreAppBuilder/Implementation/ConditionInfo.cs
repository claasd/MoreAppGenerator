using System.Text.Json.Serialization;
using MoreAppBuilder.Implementation.Model.Forms;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation;

public class ConditionInfo : ICondition
{
    [JsonIgnore] // ignore during hashing
    internal string FieldUid { get; init; }
    public Condition.TypeValue Type { get; init; }
    public string Key { get; init; }
    public JToken Value { get; init; }
    
    public string FieldObjectKey { get; init; }
}