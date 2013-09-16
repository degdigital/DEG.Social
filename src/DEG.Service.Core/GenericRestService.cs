using DEG.Service.Core.Authentication;
using DEG.Service.Core.Helpers;

namespace DEG.Service.Core
{
    public class GenericRestService
    {
        private readonly IServiceAuth _auth;

        public GenericRestService(IServiceAuth auth)
        {
            _auth = auth;
        }

        public T GetObject<T>(string url) where T : class 
        {
            string json;
            using (var client = _auth.GetAuthenticatedWebClient())
            {
                json = client.DownloadString(url);
            }

            var searchResults = JsonHelper.Parse<T>(json);
            return searchResults;
        }
    }
}
