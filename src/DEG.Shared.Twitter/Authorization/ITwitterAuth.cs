using System.Net;

namespace DEG.Shared.Twitter.Authorization
{
    //https://dev.twitter.com/docs/auth/using-oauth
    //https://dev.twitter.com/docs/auth/obtaining-access-tokens
    public interface ITwitterAuth
    {
        WebClient GetAuthenticatedWebClient();
    }
}