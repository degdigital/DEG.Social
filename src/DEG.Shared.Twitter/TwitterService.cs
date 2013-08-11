using System.IO;
using DEG.Shared.Twitter.Authorization;
using DEG.Shared.Twitter.Models;
using DEG.Shared.Twitter.Utils;

namespace DEG.Shared.Twitter
{
    public class TwitterService
    {
        private readonly ITwitterAuth _auth;

        public TwitterService(ITwitterAuth auth)
        {
            _auth = auth;
        }

        //https://dev.twitter.com/docs/api/1.1/get/statuses/user_timeline
        //
        // see also 
        //      https://dev.twitter.com/docs/api/1.1/get/statuses/mentions_timeline
        //      https://dev.twitter.com/docs/api/1.1/get/statuses/home_timeline
        //      https://dev.twitter.com/docs/api/1.1/get/statuses/retweets_of_me
        public Timeline GetUserTimeline(string screenName, int tweetCount = 10)
        {
            var timelineUrl = "https://api.twitter.com/1.1/statuses/user_timeline.json" +
                              "?screen_name=" + screenName +
                              "&count=" + tweetCount;

            var webGetReq = new AuthenticatedWebRequest(_auth, timelineUrl);

            var timelineResp = webGetReq.GetResponse();
            var respJson = new StreamReader(timelineResp.GetResponseStream() ?? new MemoryStream()).ReadToEnd();
            //var timelineObj = Json.Decode(respJson);

            return new Timeline(){ Tweets = JsonHelper.Parse<Tweet[]>(respJson)};
        }
    }
}
