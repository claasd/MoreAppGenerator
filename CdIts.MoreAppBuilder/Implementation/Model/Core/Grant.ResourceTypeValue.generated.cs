using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MoreAppBuilder.Implementation.Model.Core {
    public partial class Grant {
        // enum values for "resourceType"
        [JsonConverter(typeof(StringEnumConverter))]
        public enum ResourceTypeValue {
            [EnumMember(Value = "CUSTOMER")] CUSTOMER,
            [EnumMember(Value = "FORM")] FORM,
            [EnumMember(Value = "FOLDER")] FOLDER,
            [EnumMember(Value = "SYSTEM")] SYSTEM,
            [EnumMember(Value = "NONE")] NONE
        }
    }
}