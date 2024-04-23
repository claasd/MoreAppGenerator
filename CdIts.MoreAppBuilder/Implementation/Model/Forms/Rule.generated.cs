#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class Rule : IEquatable<Rule> {
        public const string RuleObjectName = "Rule";
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public TypeValue? Type { get; set; }

        [JsonProperty("conditions")]
        public ICollection<Condition> Conditions { get; set; }

        [JsonProperty("actions")]
        public ICollection<Action> Actions { get; set; }

        public Rule(){}
        public Rule(Rule other) {
            Name = other.Name;
            Type = other.Type == null ? null : (Rule.TypeValue)other.Type;
            Conditions = other.Conditions?.Select(value=>value?.ToCondition())?.ToList();
            Actions = other.Actions?.Select(value=>value?.ToAction())?.ToList();
        }
        public Rule ToRule() => new Rule(this);
        public bool Equals(Rule other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Name == other.Name
                && Type == other.Type
                && (Conditions?.SequenceEqual(other.Conditions) ?? other.Conditions is null)
                && (Actions?.SequenceEqual(other.Actions) ?? other.Actions is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(Rule other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as Rule);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add((int) Type);
            hashCode.Add(Conditions);
            hashCode.Add(Actions);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
