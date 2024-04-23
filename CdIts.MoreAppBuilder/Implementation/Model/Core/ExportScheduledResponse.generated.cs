#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ExportScheduledResponse : IEquatable<ExportScheduledResponse> {
        public const string ExportScheduledResponseObjectName = "ExportScheduledResponse";
        [JsonProperty("id")]
        public string Id { get; set; }

        public ExportScheduledResponse(){}
        public ExportScheduledResponse(ExportScheduledResponse other) {
            Id = other.Id;
        }
        public ExportScheduledResponse ToExportScheduledResponse() => new ExportScheduledResponse(this);
        public bool Equals(ExportScheduledResponse other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ExportScheduledResponse other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ExportScheduledResponse);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
