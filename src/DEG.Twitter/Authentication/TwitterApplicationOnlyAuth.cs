using DEG.Service.Core.Authentication;

namespace DEG.Twitter.Authentication
{
    // https://dev.twitter.com/docs/auth/application-only-auth
    public class TwitterApplicationOnlyAuth : ApplicationOnlyAuth
    {
        public TwitterApplicationOnlyAuth(string consumerKey, string consumerSecret)
            : base(consumerKey, consumerSecret, "https://api.twitter.com/oauth2/token")
        {
        }
    }
}
