using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DEG.Shared.Twitter.Models
{
    [DataContract]
    public class SearchResults
    {
        [DataMember(Name = "statuses")]
        public IEnumerable<Tweet> Tweets { get; set; }

        [DataMember(Name = "search_metadata")]
        public SearchResultsMetadata Metadata { get; set; }
    }

    [DataContract]
    public class SearchResultsMetadata
    {
        [DataMember(Name = "count")]
        public int Count { get; set; }

        [DataMember(Name = "query")]
        public string Query { get; set; }

        [DataMember(Name = "next_results")]
        public string NextResultsQueryString { get; set; }
    }
}
