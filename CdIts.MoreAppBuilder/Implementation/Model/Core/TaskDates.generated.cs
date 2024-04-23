#pragma warning disable CS0612
#pragma warning disable CS0618

using System;
using Caffoa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MoreAppBuilder.Implementation.Model.Core {
/// AUTOGENERED BY caffoa ///
    public sealed  partial class TaskDates : IEquatable<TaskDates> {
        public const string TaskDatesObjectName = "TaskDates";
        [JsonProperty("creationDate")]
        public DateTimeOffset? CreationDate { get; set; }

        [JsonProperty("publishDate")]
        public DateTimeOffset? PublishDate { get; set; }

        [JsonProperty("informationDate")]
        public DateTimeOffset? InformationDate { get; set; }

        public TaskDates(){}
        public TaskDates(TaskDates other) {
            CreationDate = other.CreationDate;
            PublishDate = other.PublishDate;
            InformationDate = other.InformationDate;
        }
        public TaskDates ToTaskDates() => new TaskDates(this);
        public bool Equals(TaskDates other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = (CreationDate?.Equals(other.CreationDate) ?? other.CreationDate is null)
                && (PublishDate?.Equals(other.PublishDate) ?? other.PublishDate is null)
                && (InformationDate?.Equals(other.InformationDate) ?? other.InformationDate is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(TaskDates other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as TaskDates);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(CreationDate);
            hashCode.Add(PublishDate);
            hashCode.Add(InformationDate);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
