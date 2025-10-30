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
    public sealed  partial class RestDataSource : IEquatable<RestDataSource> {
        public const string RestDataSourceObjectName = "RestDataSource";
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("customerId")]
        public int? CustomerId { get; set; }

        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("urlConfiguration")]
        public RestUrlConfiguration UrlConfiguration { get; set; }

        [JsonProperty("googleConfiguration")]
        public GoogleConfiguration GoogleConfiguration { get; set; }

        [JsonProperty("updateStatus")]
        public UpdateStatusValue? UpdateStatus { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset? LastUpdated { get; set; }

        [JsonProperty("lastSuccessfulUpdate")]
        public DateTimeOffset? LastSuccessfulUpdate { get; set; }

        [JsonProperty("lastUpdateType")]
        public LastUpdateTypeValue? LastUpdateType { get; set; }

        [JsonProperty("lastUpdateWarningMessages")]
        public ICollection<string> LastUpdateWarningMessages { get; set; }

        [JsonProperty("columnMapping")]
        public ICollection<DataKey> ColumnMapping { get; set; }

        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }

        [JsonProperty("failedExecutionCount")]
        public int? FailedExecutionCount { get; set; }

        [JsonProperty("version")]
        public Guid? Version { get; set; }

        public RestDataSource(){}
        public RestDataSource(RestDataSource other) {
            Id = other.Id;
            CustomerId = other.CustomerId;
            Name = other.Name;
            UrlConfiguration = other.UrlConfiguration?.ToRestUrlConfiguration();
            GoogleConfiguration = other.GoogleConfiguration?.ToGoogleConfiguration();
            UpdateStatus = other.UpdateStatus == null ? null : (RestDataSource.UpdateStatusValue)other.UpdateStatus;
            LastUpdated = other.LastUpdated;
            LastSuccessfulUpdate = other.LastSuccessfulUpdate;
            LastUpdateType = other.LastUpdateType == null ? null : (RestDataSource.LastUpdateTypeValue)other.LastUpdateType;
            LastUpdateWarningMessages = other.LastUpdateWarningMessages?.ToList();
            ColumnMapping = other.ColumnMapping?.Select(value=>value?.ToDataKey())?.ToList();
            Enabled = other.Enabled;
            FailedExecutionCount = other.FailedExecutionCount;
            Version = other.Version;
        }
        public RestDataSource ToRestDataSource() => new RestDataSource(this);
        public bool Equals(RestDataSource other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = Id == other.Id
                && CustomerId == other.CustomerId
                && Name == other.Name
                && (UrlConfiguration?.Equals(other.UrlConfiguration) ?? other.UrlConfiguration is null)
                && (GoogleConfiguration?.Equals(other.GoogleConfiguration) ?? other.GoogleConfiguration is null)
                && UpdateStatus == other.UpdateStatus
                && LastUpdated == other.LastUpdated
                && LastSuccessfulUpdate == other.LastSuccessfulUpdate
                && LastUpdateType == other.LastUpdateType
                && (other.LastUpdateWarningMessages is null ? LastUpdateWarningMessages is null : LastUpdateWarningMessages?.SequenceEqual(other.LastUpdateWarningMessages) ?? other.LastUpdateWarningMessages is null)
                && (other.ColumnMapping is null ? ColumnMapping is null : ColumnMapping?.SequenceEqual(other.ColumnMapping) ?? other.ColumnMapping is null)
                && Enabled == other.Enabled
                && FailedExecutionCount == other.FailedExecutionCount
                && Version == other.Version;
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(RestDataSource other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as RestDataSource);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Id);
            hashCode.Add(CustomerId);
            hashCode.Add(Name);
            hashCode.Add(UrlConfiguration);
            hashCode.Add(GoogleConfiguration);
            hashCode.Add((int) UpdateStatus);
            hashCode.Add(LastUpdated);
            hashCode.Add(LastSuccessfulUpdate);
            hashCode.Add((int) LastUpdateType);
            hashCode.Add(LastUpdateWarningMessages);
            hashCode.Add(ColumnMapping);
            hashCode.Add(Enabled);
            hashCode.Add(FailedExecutionCount);
            hashCode.Add(Version);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
