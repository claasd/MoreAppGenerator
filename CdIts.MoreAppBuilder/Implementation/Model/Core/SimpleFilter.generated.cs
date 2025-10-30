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
    public sealed  partial class SimpleFilter : IEquatable<SimpleFilter> {
        public const string SimpleFilterObjectName = "SimpleFilter";
        /// <summary>
        /// The amount of results per page
        /// </summary>
        [JsonProperty("pageSize")]
        public int? PageSize { get; set; }

        /// <summary>
        /// Sort the results based on the given field
        /// </summary>
        [JsonProperty("sort")]
        public ICollection<SortProperty> Sort { get; set; }

        /// <summary>
        /// Filter results based on the given predicate(s)
        /// </summary>
        [JsonProperty("query")]
        public ICollection<FilterQuery> Query { get; set; }

        public SimpleFilter(){}
        public SimpleFilter(SimpleFilter other) {
            PageSize = other.PageSize;
            Sort = other.Sort?.Select(value=>value?.ToSortProperty())?.ToList();
            Query = other.Query?.Select(value=>value?.ToFilterQuery())?.ToList();
        }
        public SimpleFilter ToSimpleFilter() => new SimpleFilter(this);
        public bool Equals(SimpleFilter other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            var result = PageSize == other.PageSize
                && (other.Sort is null ? Sort is null : Sort?.SequenceEqual(other.Sort) ?? other.Sort is null)
                && (other.Query is null ? Query is null : Query?.SequenceEqual(other.Query) ?? other.Query is null);
            if(result) _PartialEquals(other, ref result);
            return result;
        }
        partial void _PartialEquals(SimpleFilter other, ref bool result);
        public override bool Equals(object obj) => Equals(obj as SimpleFilter);
        public override int GetHashCode() {
            var hashCode = new HashCode();
            hashCode.Add(PageSize);
            hashCode.Add(Sort);
            hashCode.Add(Query);
            _PartialHashCode(ref hashCode);
            return hashCode.ToHashCode();
        }
        partial void _PartialHashCode(ref HashCode hashCode);
    }
}
