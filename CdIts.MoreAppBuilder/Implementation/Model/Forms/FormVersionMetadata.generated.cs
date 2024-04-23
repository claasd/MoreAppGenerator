#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Immutable;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FormVersionMetadata : IEquatable<FormVersionMetadata> {
        public const string FormVersionMetadataObjectName = "FormVersionMetadata";
        [JsonProperty("created")]
        public DateTimeOffset? Created { get; set; }

        [JsonProperty("createdBy")]
        public string CreatedBy { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("lastUpdatedBy")]
        public string LastUpdatedBy { get; set; }

        [JsonProperty("status")]
        public StatusValue? Status { get; set; }

        public FormVersionMetadata(){}
        public FormVersionMetadata(FormVersionMetadata other) {
            Created = other.Created;
            CreatedBy = other.CreatedBy;
            LastUpdated = other.LastUpdated;
            LastUpdatedBy = other.LastUpdatedBy;
            Status = other.Status == null ? null : (FormVersionMetadata.StatusValue)other.Status;
        }
        public FormVersionMetadata ToFormVersionMetadata() => new FormVersionMetadata(this);
        public bool Equals(FormVersionMetadata other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (Created?.Equals(other.Created) ?? other.Created is null)
                && CreatedBy == other.CreatedBy
                && (LastUpdated?.Equals(other.LastUpdated) ?? other.LastUpdated is null)
                && LastUpdatedBy == other.LastUpdatedBy
                && Status == other.Status;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormVersionMetadata other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormVersionMetadata);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Created);
            hashCode.Add(CreatedBy);
            hashCode.Add(LastUpdated);
            hashCode.Add(LastUpdatedBy);
            hashCode.Add((int) Status);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
