using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DEG.Shared.Twitter.Models
{
    [DataContract]
    public class SearchResults
    {
        [DataMember(Name = "statuses")]
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
