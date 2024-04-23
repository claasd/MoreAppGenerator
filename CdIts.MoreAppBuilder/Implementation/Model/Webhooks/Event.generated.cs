#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Webhooks {
/// AUTOGENERED BY caffoa ///
    /// <summary>
    /// When an user performs certain actions, like sending submissions or creating tasks, an event will be created. These events contain relevant information, like the entire submission or task that has been created.
    /// </summary>
    public sealed  partial class Event : IEquatable<Event> {
        public const string EventObjectName = "Event";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("customerId")]
        public long? CustomerId { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("idempotencyKey")]
        public string IdempotencyKey { get; set; }

        [JsonProperty("data")]
        public Dictionary<string, object> Data { get; set; }

        public Event(){}
        public Event(Event other) {
            Id = other.Id;
            Timestamp = other.Timestamp;
            CustomerId = other.CustomerId;
            Type = other.Type;
            IdempotencyKey = other.IdempotencyKey;
            Data = other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value);
        }
        public Event ToEvent() => new Event(this);
        public bool Equals(Event other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Timestamp == other.Timestamp
                && CustomerId == other.CustomerId
                && Type == other.Type
                && IdempotencyKey == other.IdempotencyKey
                && (Data?.SequenceEqual(other.Data) ?? other.Data is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Event other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Event);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Timestamp);
            hashCode.Add(CustomerId);
            hashCode.Add(Type);
            hashCode.Add(IdempotencyKey);
            hashCode.Add(Data);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
