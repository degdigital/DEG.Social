using System.Collections.Generic;

namespace DEG.Twitter.Models
{
    public class Timeline
    {
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
