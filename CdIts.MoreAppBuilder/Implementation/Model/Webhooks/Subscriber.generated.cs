#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Webhooks {
/// AUTOGENERED BY caffoa ///
    /// <summary>
    /// As a developer/power user you can subscribe to events. This means whenever an user triggers an event, the system will invoke a message to your webhook containing a payload describing the event.
    /// </summary>
    public sealed  partial class Subscriber : IEquatable<Subscriber> {
        public const string SubscriberObjectName = "Subscriber";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("url", Required = Required.Always)]
        public string Url { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("type", Required = Required.Always)]
        public ICollection<string> Type { get; set; } = new List<string>();

        [JsonProperty("status", Required = Required.Always)]
        public StatusValue Status { get; set; }

        [JsonProperty("secret")]
        public string Secret { get; set; }

        public Subscriber(){}
        public Subscriber(Subscriber other) {
            Id = other.Id;
            Url = other.Url;
            Name = other.Name;
            Type = other.Type?.ToList();
            Status = (Subscriber.StatusValue)other.Status;
            Secret = other.Secret;
        }
        public Subscriber ToSubscriber() => new Subscriber(this);
        public bool Equals(Subscriber other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && Url == other.Url
                && Name == other.Name
                && (Type?.SequenceEqual(other.Type) ?? other.Type is null)
                && Status == other.Status
                && Secret == other.Secret;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Subscriber other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Subscriber);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(Url);
            hashCode.Add(Name);
            hashCode.Add(Type);
            hashCode.Add((int) Status);
            hashCode.Add(Secret);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
