#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class TaskPublishInfo : IEquatable<TaskPublishInfo> {
        public const string TaskPublishInfoObjectName = "TaskPublishInfo";
        [JsonProperty("type", Required = Required.Always)]
        public TypeValue Type { get; set; }

        [JsonProperty("value")]
        public long? Value { get; set; }

        public TaskPublishInfo(){}
        public TaskPublishInfo(TaskPublishInfo other) {
            Type = (TaskPublishInfo.TypeValue)other.Type;
            Value = other.Value;
        }
        public TaskPublishInfo ToTaskPublishInfo() => new TaskPublishInfo(this);
        public bool Equals(TaskPublishInfo other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Type == other.Type
                && Value == other.Value;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(TaskPublishInfo other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as TaskPublishInfo);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) Type);
            hashCode.Add(Value);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
