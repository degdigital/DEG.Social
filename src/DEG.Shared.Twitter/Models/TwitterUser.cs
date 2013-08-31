using System.Runtime.Serialization;

namespace DEG.Shared.Twitter.Models
{
    [DataContract]
    public class TwitterUser
    {
        [DataMember(Name = "screen_name")]
        public string ScreenName { get; set; }
    }
}
