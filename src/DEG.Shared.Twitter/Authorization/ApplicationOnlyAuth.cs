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

        private void Authenticate()
        {
            var encodedConsumerKey = HttpUtility.UrlEncode(_consumerKey);
            var encodedConsumerSecret = HttpUtility.UrlEncode(_consumerSecret);

            var combined = string.Format("{0}:{1}", encodedConsumerKey, encodedConsumerSecret);

            var base64Token = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(combined));

            using (var client = new WebClient())
            {
                client.Headers.Clear();
                client.Headers.Add(HttpRequestHeader.Authorization, "Basic " + base64Token);
                var respBytes = client.UploadValues(
                    "https://api.twitter.com/oauth2/token",
                    new NameValueCollection
                    {
                        {"grant_type", "client_credentials"}
                    });
                var response = System.Text.Encoding.UTF8.GetString(respBytes);
                var authResponse = Json.Decode(response);

                if (authResponse.token_type != "bearer")
                {
                    throw new TwitterAuthenticationFailedException("Authentication attempt did not return expected bearer token.");
                }

                _bearerToken = authResponse.access_token;
            }
        }

        public NameValueCollection GetRequestHeaders()
        {
            if (string.IsNullOrEmpty(_bearerToken))
                Authenticate();

            return new NameValueCollection
                       {
                           {HttpRequestHeader.Authorization.ToString(), "Bearer " + _bearerToken}
                       };
        }
    }
}
