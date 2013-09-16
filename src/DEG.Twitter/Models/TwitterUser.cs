using System.Runtime.Serialization;

namespace DEG.Twitter.Models
{
    [DataContract]
    public class TwitterUser
    {
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }
    }
}
