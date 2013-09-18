using System.Collections.Generic;
using DEG.Service.Core;
using DEG.Service.Core.Authentication;
using DEG.Twitter.Models;

namespace DEG.Twitter
{
    public interface ITwitterService
    {
        Timeline GetUserTimeline(string screenName, int tweetCount = 10);
        IEnumerable<Tweet> GetMentions(string screenName, int tweetCount = 10);
        IEnumerable<Tweet> GetTweetsWithHashtag(string hashtag, int tweetCount = 10);
    }

    public class TwitterService : GenericRestService, ITwitterService
    {
        private const string TwitterApiBaseUrl = "https://api.twitter.com/1.1/";
        private const string TweetsApiUrl = TwitterApiBaseUrl + "search/tweets.json";
        private const string TimelineApiUrl = TwitterApiBaseUrl + "statuses/user_timeline.json";

        public TwitterService(IServiceAuth auth) : base(auth)
        {}

        //https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline
        //
        // see also 
        //      https://dev.twitter.com/docs/api/1.1/get/statuses/mentions_timeline
        //      https://dev.twitter.com/docs/api/1.1/get/statuses/home_timeline
        //      https://dev.twitter.com/docs/api/1.1/get/statuses/retweets_of_me
        public Timeline GetUserTimeline(string screenName, int tweetCount = 10)
        {
            var timelineUrl = TimelineApiUrl +
                              "?screen_name=" + screenName +
                              "&count=" + tweetCount;

            return new Timeline {Tweets = GetObject<Tweet[]>(timelineUrl)};
        }

        public IEnumerable<Tweet> GetMentions(string screenName, int tweetCount = 10)
        {
            var mentionsUrl = TweetsApiUrl +
                 "?q=%40" + screenName +
                 "&count=" + tweetCount;

            var searchResults = GetObject<SearchResults>(mentionsUrl);
            return searchResults.Tweets;
        }

        public IEnumerable<Tweet> GetTweetsWithHashtag(string hashtag, int tweetCount = 10)
        {
            var hashtagUrl = TweetsApiUrl +
                             "?q=%23" + hashtag +
                             "&count=" + tweetCount;

            var searchResults = GetObject<SearchResults>(hashtagUrl);
            return searchResults.Tweets;
        }
    }
}
