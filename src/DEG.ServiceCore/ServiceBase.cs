using DEG.ServiceCore.Authentication;
using DEG.ServiceCore.Helpers;

namespace DEG.ServiceCore
{
    public class ServiceBase
    {
        private readonly IServiceAuth _auth;

        public ServiceBase(IServiceAuth auth)
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
