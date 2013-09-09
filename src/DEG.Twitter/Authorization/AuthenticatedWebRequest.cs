using System.Net;

namespace DEG.Shared.Twitter.Authorization
{
    //https://dev.twitter.com/docs/auth/obtaining-access-tokens
    public class AuthenticatedWebRequest
    {
        private readonly ITwitterAuth _auth;
        private readonly WebRequest _webRequest;

        public AuthenticatedWebRequest(ITwitterAuth auth, string url)
        {
            _auth = auth;
            _webRequest = WebRequest.Create(url);
        }

        public WebResponse GetResponse()
        {
            _webRequest.Headers.Clear();
            _webRequest.Headers.Add(_auth.GetRequestHeaders());

            return _webRequest.GetResponse();
        }
    }
}
