using System.Net;

namespace DEG.Service.Core.Authentication
{
    public class NoAuthentication : IServiceAuth
    {
        public WebClient GetAuthenticatedWebClient()
        {
            return new WebClient();
        }
    }
}
