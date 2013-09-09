using System.Collections.Generic;

namespace DEG.Shared.Twitter.Models
{
    public class Timeline
    {
        public IEnumerable<Tweet> Tweets { get; set; }
    }
}
