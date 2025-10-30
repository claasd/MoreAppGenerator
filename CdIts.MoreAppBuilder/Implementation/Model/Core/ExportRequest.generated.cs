#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Immutable;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class ExportRequest : IEquatable<ExportRequest> {
        public const string ExportRequestObjectName = "ExportRequest";
        [JsonProperty("exporterType", Required = Required.Always)]
        public ExporterTypeValue ExporterType { get; set; }

        [JsonProperty("submissionIds")]
        public ICollection<string> SubmissionIds { get; set; }

        [JsonProperty("exportFields", Required = Required.Always)]
        public ICollection<ExportField> ExportFields { get; set; } = new List<ExportField>();

        [JsonProperty("mailOnFinish", Required = Required.Always)]
        public ICollection<string> MailOnFinish { get; set; } = new List<string>();

        [JsonProperty("options", Required = Required.Always)]
        public ExportOptions Options { get; set; } = new ExportOptions();

        [JsonProperty("filterQueries")]
        public ICollection<FilterQuery> FilterQueries { get; set; }

        public ExportRequest(){}
        public ExportRequest(ExportRequest other) {
            ExporterType = (ExportRequest.ExporterTypeValue)other.ExporterType;
            SubmissionIds = other.SubmissionIds?.ToList();
            ExportFields = other.ExportFields?.Select(value=>value?.ToExportField())?.ToList();
            MailOnFinish = other.MailOnFinish?.ToList();
            Options = other.Options?.ToExportOptions();
            FilterQueries = other.FilterQueries?.Select(value=>value?.ToFilterQuery())?.ToList();
        }
        public ExportRequest ToExportRequest() => new ExportRequest(this);
        public bool Equals(ExportRequest other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = ExporterType == other.ExporterType
                && (other.SubmissionIds is null ? SubmissionIds is null : SubmissionIds?.SequenceEqual(other.SubmissionIds) ?? other.SubmissionIds is null)
                && (other.ExportFields is null ? ExportFields is null : ExportFields?.SequenceEqual(other.ExportFields) ?? other.ExportFields is null)
                && (other.MailOnFinish is null ? MailOnFinish is null : MailOnFinish?.SequenceEqual(other.MailOnFinish) ?? other.MailOnFinish is null)
                && (Options?.Equals(other.Options) ?? other.Options is null)
                && (other.FilterQueries is null ? FilterQueries is null : FilterQueries?.SequenceEqual(other.FilterQueries) ?? other.FilterQueries is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(ExportRequest other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as ExportRequest);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add((int) ExporterType);
            hashCode.Add(SubmissionIds);
            hashCode.Add(ExportFields);
            hashCode.Add(MailOnFinish);
            hashCode.Add(Options);
            hashCode.Add(FilterQueries);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
