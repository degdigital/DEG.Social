using System.Collections.Generic;

namespace DEG.Shared.Twitter.Models
{
    public class Timeline
    {
        //public static Timeline Parse(dynamic src)
        //{
        //    return new Timeline()
        //               {
        //                   Tweets = ((IEnumerable<object>)src).Select(Tweet.Parse)
        //               };
        //}

        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
