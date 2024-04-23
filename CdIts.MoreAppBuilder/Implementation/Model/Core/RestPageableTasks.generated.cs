#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class RestPageableTasks : IEquatable<RestPageableTasks> {
        public const string RestPageableTasksObjectName = "RestPageableTasks";
        [JsonProperty("totalSize")]
        public long? TotalSize { get; set; }

        [JsonProperty("elements")]
        public ICollection<RestTask> Elements { get; set; }

        public RestPageableTasks(){}
        public RestPageableTasks(RestPageableTasks other) {
            TotalSize = other.TotalSize;
            Elements = other.Elements?.Select(value=>value?.ToRestTask())?.ToList();
        }
        public RestPageableTasks ToRestPageableTasks() => new RestPageableTasks(this);
        public bool Equals(RestPageableTasks other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = TotalSize == other.TotalSize
                && (Elements?.SequenceEqual(other.Elements) ?? other.Elements is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestPageableTasks other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestPageableTasks);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(TotalSize);
            hashCode.Add(Elements);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
