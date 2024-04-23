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
    public sealed  partial class JsonError : IEquatable<JsonError> {
        public const string JsonErrorObjectName = "JsonError";
        [JsonProperty("status")]
        public int? Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("scope")]
        public ScopeValue? Scope { get; set; }

        [JsonProperty("traceId")]
        public string TraceId { get; set; }

        [JsonProperty("details")]
        public JsonErrorDetails Details { get; set; }

        public JsonError(){}
        public JsonError(JsonError other) {
            Status = other.Status;
            Message = other.Message;
            Scope = other.Scope == null ? null : (JsonError.ScopeValue)other.Scope;
            TraceId = other.TraceId;
            Details = other.Details?.ToJsonErrorDetails();
        }
        public JsonError ToJsonError() => new JsonError(this);
        public bool Equals(JsonError other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Status == other.Status
                && Message == other.Message
                && Scope == other.Scope
                && TraceId == other.TraceId
                && (Details?.Equals(other.Details) ?? other.Details is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(JsonError other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as JsonError);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Status);
            hashCode.Add(Message);
            hashCode.Add((int) Scope);
            hashCode.Add(TraceId);
            hashCode.Add(Details);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
