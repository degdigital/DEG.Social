using System;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;
using DEG.ServiceCore.Exceptions;
using DEG.ServiceCore.Helpers;
using DEG.ServiceCore.Models;

namespace DEG.ServiceCore.Authentication
{
    public class ApplicationOnlyAuth : IServiceAuth
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private string _bearerToken;
        private readonly string _authTokenUrl;

        public ApplicationOnlyAuth(string consumerKey, string consumerSecret, string authTokenUrl)
        {
            if (string.IsNullOrEmpty(consumerKey))
                throw new InvalidConsumerKeyException("Consumer key is required for application-only authentication.");
            if (string.IsNullOrEmpty(consumerSecret))
                throw new InvalidConsumerSecretException("Consumer secret is required for application-only authentication.");

            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
            _authTokenUrl = authTokenUrl;
        }
        public ApplicationOnlyAuth(string bearerToken)
        {
            if (string.IsNullOrEmpty(bearerToken))
                throw new InvalidBearerTokenException("Bearer token is required for application-only authentication.");

            _bearerToken = bearerToken;
        }

        public WebClient GetAuthenticatedWebClient()
        {
            if (string.IsNullOrEmpty(_bearerToken))
                _bearerToken = RetrieveBearerToken();

            var client = new WebClient();
            client.Headers.Clear();
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _bearerToken);

            return client;
        }

        public string GetAuthenticatedUrl(string url)
        {
            return url;
        }

        protected virtual string RetrieveBearerToken()
        {
            var encodedConsumerKey = HttpUtility.UrlEncode(_consumerKey);
            var encodedConsumerSecret = HttpUtility.UrlEncode(_consumerSecret);

            var combined = string.Format("{0}:{1}", encodedConsumerKey, encodedConsumerSecret);

            var base64Token = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(combined));

            using (var client = new WebClient())
            {
                client.Headers.Clear();
                client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + base64Token);
                byte[] respBytes;
                try
                {
                    respBytes = client.UploadValues(
                        _authTokenUrl,
                        new NameValueCollection
                            {
                                {"grant_type", "client_credentials"}
                            });
                }
                catch (Exception ex)
                {
                    throw new AuthenticationFailedException("Error contacting server to retrieve bearer token.", ex);
                }
                var response = System.Text.Encoding.UTF8.GetString(respBytes);

                ClientCredentialsResponse authResponse;
                try
                {
                    authResponse =  JsonHelper.Parse<ClientCredentialsResponse>(response);
                }
                catch
                {
                    authResponse = null;
                }

                if (authResponse == null || authResponse.TokenType != "bearer")
                {
                    var message = "Authentication attempt did not return expected bearer token.";
                    if (authResponse == null)
                        message += " Response: " + response;
                    else if (authResponse.Errors != null && authResponse.Errors.Any())
                        message += " Errors: " + string.Join(", ", authResponse.Errors.Select(x => x.Message));

                    throw new AuthenticationFailedException(message);
                }

                return authResponse.AccessToken;
            }
        }
    }
}
