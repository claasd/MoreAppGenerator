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
    public sealed  partial class TriggerConfiguration : IEquatable<TriggerConfiguration> {
        public const string TriggerConfigurationObjectName = "TriggerConfiguration";
        [JsonProperty("attachments")]
        public ICollection<string> Attachments { get; set; }

        [JsonProperty("attachImages")]
        public bool? AttachImages { get; set; }

        [JsonProperty("embedImages")]
        public bool? EmbedImages { get; set; }

        [JsonProperty("attachPdf")]
        public bool? AttachPdf { get; set; }

        [JsonProperty("simpleMode")]
        public bool? SimpleMode { get; set; }

        [JsonProperty("useHeaderAndFooter")]
        public bool? UseHeaderAndFooter { get; set; }

        [JsonProperty("hideNoValues")]
        public bool? HideNoValues { get; set; }

        [JsonProperty("horizontalOrientation")]
        public bool? HorizontalOrientation { get; set; }

        [JsonProperty("distributedGeneration")]
        public bool? DistributedGeneration { get; set; }

        [JsonProperty("legacyGeneration")]
        public bool? LegacyGeneration { get; set; }

        public TriggerConfiguration(){}
        public TriggerConfiguration(TriggerConfiguration other) {
            Attachments = other.Attachments?.ToList();
            AttachImages = other.AttachImages;
            EmbedImages = other.EmbedImages;
            AttachPdf = other.AttachPdf;
            SimpleMode = other.SimpleMode;
            UseHeaderAndFooter = other.UseHeaderAndFooter;
            HideNoValues = other.HideNoValues;
            HorizontalOrientation = other.HorizontalOrientation;
            DistributedGeneration = other.DistributedGeneration;
            LegacyGeneration = other.LegacyGeneration;
        }
        public TriggerConfiguration ToTriggerConfiguration() => new TriggerConfiguration(this);
        public bool Equals(TriggerConfiguration other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Attachments?.SequenceEqual(other.Attachments) ?? other.Attachments is null)
                && AttachImages == other.AttachImages
                && EmbedImages == other.EmbedImages
                && AttachPdf == other.AttachPdf
                && SimpleMode == other.SimpleMode
                && UseHeaderAndFooter == other.UseHeaderAndFooter
                && HideNoValues == other.HideNoValues
                && HorizontalOrientation == other.HorizontalOrientation
                && DistributedGeneration == other.DistributedGeneration
                && LegacyGeneration == other.LegacyGeneration;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(TriggerConfiguration other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as TriggerConfiguration);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Attachments);
            hashCode.Add(AttachImages);
            hashCode.Add(EmbedImages);
            hashCode.Add(AttachPdf);
            hashCode.Add(SimpleMode);
            hashCode.Add(UseHeaderAndFooter);
            hashCode.Add(HideNoValues);
            hashCode.Add(HorizontalOrientation);
            hashCode.Add(DistributedGeneration);
            hashCode.Add(LegacyGeneration);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
