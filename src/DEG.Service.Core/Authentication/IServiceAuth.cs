using System.Net;

namespace DEG.Service.Core.Authentication
{
    //https://dev.twitter.com/docs/auth/using-oauth
    //https://dev.twitter.com/docs/auth/obtaining-access-tokens
    public interface IServiceAuth
    {
        WebClient GetAuthenticatedWebClient();
    }
}