using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class JsonError {
        // enum values for "scope"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ScopeValue {
            [EnumMember(Value = "SECURITY")] SECURITY,
            [EnumMember(Value = "INVALID_REQUEST_DATA")] INVALID_REQUEST_DATA,
            [EnumMember(Value = "VALIDATION")] VALIDATION,
            [EnumMember(Value = "SERVER_ERROR")] SERVER_ERROR,
            [EnumMember(Value = "INVALID_REQUEST")] INVALID_REQUEST
        }
    }
}