#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Webhooks {
/// AUTOGENERED BY caffoa ///
    /// <summary>
    /// An invocation is an attempt to send an event to a subscriber. If the invocation succeeds, it's marked as successful. Otherwise multiple delayed attempts will be made to ensure the event arrives to the webhook URL of the subscriber.
    /// </summary>
    public sealed  partial class InvocationResult : IEquatable<InvocationResult> {
        public const string InvocationResultObjectName = "InvocationResult";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("subscriberId")]
        public string SubscriberId { get; set; }

        [JsonProperty("eventId")]
        public string EventId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("customerId")]
        public long? CustomerId { get; set; }

        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("invokedOn")]
        public string InvokedOn { get; set; }

        [JsonProperty("retryOn")]
        public string RetryOn { get; set; }

        [JsonProperty("attempt")]
        public int? Attempt { get; set; }

        public InvocationResult(){}
        public InvocationResult(InvocationResult other) {
            Id = other.Id;
            SubscriberId = other.SubscriberId;
            EventId = other.EventId;
            Type = other.Type;
            CustomerId = other.CustomerId;
            Status = other.Status == null ? null : (InvocationResult.StatusValue)other.Status;
            Message = other.Message;
            InvokedOn = other.InvokedOn;
            RetryOn = other.RetryOn;
            Attempt = other.Attempt;
        }
        public InvocationResult ToInvocationResult() => new InvocationResult(this);
        public bool Equals(InvocationResult other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && SubscriberId == other.SubscriberId
                && EventId == other.EventId
                && Type == other.Type
                && CustomerId == other.CustomerId
                && Status == other.Status
                && Message == other.Message
                && InvokedOn == other.InvokedOn
                && RetryOn == other.RetryOn
                && Attempt == other.Attempt;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(InvocationResult other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as InvocationResult);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(SubscriberId);
            hashCode.Add(EventId);
            hashCode.Add(Type);
            hashCode.Add(CustomerId);
            hashCode.Add((int) Status);
            hashCode.Add(Message);
            hashCode.Add(InvokedOn);
            hashCode.Add(RetryOn);
            hashCode.Add(Attempt);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
