using System;
using System.Collections.Specialized;
using System.Net;
using System.Web;
using System.Web.Helpers;
using DEG.Shared.Twitter.Exceptions;

namespace DEG.Shared.Twitter.Authorization
{
    // https://dev.twitter.com/docs/auth/application-only-auth
    public class ApplicationOnlyAuth : ITwitterAuth
    {
        private readonly string _consumerKey;
        private readonly string _consumerSecret;
        private string _bearerToken;

        public ApplicationOnlyAuth(string consumerKey, string consumerSecret)
        {
            _consumerKey = consumerKey;
            _consumerSecret = consumerSecret;
        }
        public ApplicationOnlyAuth(string bearerToken)
        {
            _bearerToken = bearerToken;
        }

        public WebClient GetAuthenticatedWebClient()
        {
            if (string.IsNullOrEmpty(_bearerToken))
                RetrieveBearerToken();

            var client = new WebClient();
            client.Headers.Clear();
            client.Headers.Add(HttpRequestHeader.Authorization, "Bearer " + _bearerToken);

            return client;
        }

        private void RetrieveBearerToken()
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
                        "https://api.twitter.com/oauth2/token",
                        new NameValueCollection
                            {
                                {"grant_type", "client_credentials"}
                            });
                }
                catch (Exception ex)
                {
                    throw new TwitterAuthenticationFailedException("Error contacting server to retrieve bearer token.", ex);
                }
                var response = System.Text.Encoding.UTF8.GetString(respBytes);

                dynamic authResponse;
                try
                {
                    authResponse = Json.Decode(response);
                }
                catch
                {
                    authResponse = null;
                }

                if (authResponse == null || authResponse.token_type != "bearer")
                {
                    throw new TwitterAuthenticationFailedException("Authentication attempt did not return expected bearer token.");
                }

                _bearerToken = authResponse.access_token;
            }
        }
    }
}
