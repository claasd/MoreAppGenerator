#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class TaskCreateRequest : IEquatable<TaskCreateRequest> {
        public const string TaskCreateRequestObjectName = "TaskCreateRequest";
        [JsonProperty("recipients", Required = Required.Always)]
        public ICollection<string> Recipients { get; set; } = new List<string>();

        [JsonProperty("message", Required = Required.Always)]
        public string Message { get; set; }

        [JsonProperty("data", Required = Required.Always)]
        public Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>();

        [JsonProperty("informationDate")]
        public DateTimeOffset? InformationDate { get; set; }

        [JsonProperty("publishDate")]
        public TaskPublishInfo PublishDate { get; set; }

        [JsonProperty("publishInfo", Required = Required.Always)]
        public TaskPublishInfo PublishInfo { get; set; } = new TaskPublishInfo();

        public TaskCreateRequest(){}
        public TaskCreateRequest(TaskCreateRequest other) {
            Recipients = other.Recipients?.ToList();
            Message = other.Message;
            Data = other.Data?.ToDictionary(entry => entry.Key, entry => entry.Value);
            InformationDate = other.InformationDate;
            PublishDate = other.PublishDate?.ToTaskPublishInfo();
            PublishInfo = other.PublishInfo?.ToTaskPublishInfo();
        }
        public TaskCreateRequest ToTaskCreateRequest() => new TaskCreateRequest(this);
        public bool Equals(TaskCreateRequest other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (other.Recipients is null ? Recipients is null : Recipients?.SequenceEqual(other.Recipients) ?? other.Recipients is null)
                && Message == other.Message
                && (other.Data is null ? Data is null : Data?.SequenceEqual(other.Data) ?? other.Data is null)
                && InformationDate == other.InformationDate
                && (PublishDate?.Equals(other.PublishDate) ?? other.PublishDate is null)
                && (PublishInfo?.Equals(other.PublishInfo) ?? other.PublishInfo is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(TaskCreateRequest other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as TaskCreateRequest);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(Recipients);
            hashCode.Add(Message);
            hashCode.Add(Data);
            hashCode.Add(InformationDate);
            hashCode.Add(PublishDate);
            hashCode.Add(PublishInfo);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
