using System.Net;
using DEG.Service.Core.Exceptions;

namespace DEG.Service.Core.Authentication
{
    public class SimpleAuth : IServiceAuth
    {
        private string _apiKey;

        public SimpleAuth(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new InvalidApiKeyException("API key is required for simple authentication.");

            _apiKey = apiKey;
        }

        public WebClient GetAuthenticatedWebClient()
        {
            return new WebClient();
        }
    }
}
