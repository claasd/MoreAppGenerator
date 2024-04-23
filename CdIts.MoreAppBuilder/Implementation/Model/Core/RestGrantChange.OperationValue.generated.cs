using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class RestGrantChange {
        // enum values for "operation"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum OperationValue {
            [EnumMember(Value = "ADD")] ADD,
            [EnumMember(Value = "REMOVE")] REMOVE,
            [EnumMember(Value = "UPDATE")] UPDATE
        }
    }
}