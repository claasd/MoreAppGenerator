#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Forms {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class FormPublishedVersionDto : IEquatable<FormPublishedVersionDto> {
        public const string FormPublishedVersionDtoObjectName = "FormPublishedVersionDto";
        [JsonProperty("formVersion")]
        public string FormVersion { get; set; }

        [JsonProperty("publishedDate")]
        public DateTimeOffset? PublishedDate { get; set; }

        [JsonProperty("publishedBy")]
        public string PublishedBy { get; set; }

        [JsonProperty("remarks")]
        public string Remarks { get; set; }

        public FormPublishedVersionDto(){}
        public FormPublishedVersionDto(FormPublishedVersionDto other) {
            FormVersion = other.FormVersion;
            PublishedDate = other.PublishedDate;
            PublishedBy = other.PublishedBy;
            Remarks = other.Remarks;
        }
        public FormPublishedVersionDto ToFormPublishedVersionDto() => new FormPublishedVersionDto(this);
        public bool Equals(FormPublishedVersionDto other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = FormVersion == other.FormVersion
                && (PublishedDate?.Equals(other.PublishedDate) ?? other.PublishedDate is null)
                && PublishedBy == other.PublishedBy
                && Remarks == other.Remarks;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(FormPublishedVersionDto other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as FormPublishedVersionDto);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(FormVersion);
            hashCode.Add(PublishedDate);
            hashCode.Add(PublishedBy);
            hashCode.Add(Remarks);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
