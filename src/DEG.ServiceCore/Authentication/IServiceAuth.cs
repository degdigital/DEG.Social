using System.Net;

namespace DEG.ServiceCore.Authentication
{
    //https://dev.twitter.com/docs/auth/using-oauth
    //https://dev.twitter.com/docs/auth/obtaining-access-tokens
    public interface IServiceAuth
    {
        WebClient GetAuthenticatedWebClient();
        string GetAuthenticatedUrl(string url);
    }
}