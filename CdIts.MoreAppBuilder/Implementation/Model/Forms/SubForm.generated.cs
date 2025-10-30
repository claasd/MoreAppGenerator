#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class SubForm : IEquatable<SubForm> {
        public const string SubFormObjectName = "SubForm";
        [JsonProperty("uid")]
        public string Uid { get; set; }

        [JsonProperty("fields")]
        public ICollection<Field> Fields { get; set; }

        [JsonProperty("rules")]
        public ICollection<Rule> Rules { get; set; }

        [JsonProperty("triggers")]
        public ICollection<Trigger> Triggers { get; set; }

        [JsonProperty("settings")]
        public Settings Settings { get; set; }

        public SubForm(){}
        public SubForm(SubForm other) {
            Uid = other.Uid;
            Fields = other.Fields?.Select(value=>value?.ToField())?.ToList();
            Rules = other.Rules?.Select(value=>value?.ToRule())?.ToList();
            Triggers = other.Triggers?.Select(value=>value?.ToTrigger())?.ToList();
            Settings = other.Settings?.ToSettings();
        }
        public SubForm ToSubForm() => new SubForm(this);
        public bool Equals(SubForm other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Uid == other.Uid
                && (other.Fields is null ? Fields is null : Fields?.SequenceEqual(other.Fields) ?? other.Fields is null)
                && (other.Rules is null ? Rules is null : Rules?.SequenceEqual(other.Rules) ?? other.Rules is null)
                && (other.Triggers is null ? Triggers is null : Triggers?.SequenceEqual(other.Triggers) ?? other.Triggers is null)
                && (Settings?.Equals(other.Settings) ?? other.Settings is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(SubForm other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as SubForm);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Uid);
            hashCode.Add(Fields);
            hashCode.Add(Rules);
            hashCode.Add(Triggers);
            hashCode.Add(Settings);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
