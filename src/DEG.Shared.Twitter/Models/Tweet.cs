using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace DEG.Shared.Twitter.Models
{
    //https://dev.twitter.com/docs/platform-objects/tweets
    [DataContract]
    public class Tweet
    {
        [DataMember(Name = "retweeted")]
        public bool Retweeted { get; set; }
        [DataMember(Name = "retweet_count")]
        public long? RetweetCount { get; set; }
        [DataMember(Name = "id")]
        public long Id { get; set; }
        [DataMember(Name = "favorited")]
        public bool Favorited { get; set; }
        [DataMember(Name = "created_at")]
        public string OriginalCreatedAtString { get; set; }
        [DataMember(Name = "favorite_count")]
        public long? FavoriteCount { get; set; }
        [DataMember(Name = "text")]
        public string Text { get; set; }

        [IgnoreDataMember]
        public DateTime Created
        {
            get
            {
                DateTime createdDate;
                DateTime.TryParseExact(OriginalCreatedAtString,
                                       "ddd MMM dd HH:mm:ss zz00 yyyy",
                                       CultureInfo.InvariantCulture,
                                       DateTimeStyles.AssumeUniversal,
                                       out createdDate);
                return createdDate;
            }
        }

    }
}
