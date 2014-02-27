using System;
using System.Net;
using DEG.ServiceCore.Exceptions;

namespace DEG.ServiceCore.Authentication
{
    public class SimpleKeyAuth : IServiceAuth
    {
        private readonly string _apiToken;
        private readonly string _apiTokenKey;

        public SimpleKeyAuth(string apiTokenKey, string apiToken)
        {
            if (string.IsNullOrEmpty(apiTokenKey))
                throw new InvalidConsumerSecretException("API token key is required for simple key authentication.");
            if (string.IsNullOrEmpty(apiToken))
                throw new InvalidConsumerKeyException("API token is required for simple key authentication.");

            _apiToken = apiToken;
            _apiTokenKey = apiTokenKey;
        }

        public WebClient GetAuthenticatedWebClient()
        {
            var client = new WebClient();
            client.Headers.Clear();
            client.Headers.Add(_apiTokenKey, _apiToken);

            return client;
        }

        public string GetAuthenticatedUrl(string url)
        {
            return url + (url.Contains("?") ? "&" : "?") + _apiTokenKey + "=" + _apiToken;
        }
    }
}
