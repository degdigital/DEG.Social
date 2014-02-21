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
            var resultString = GetString(url);

            T results;
            if (JsonHelper.TryParse(resultString, out results))
                return results;
            if (XmlHelper.TryParse(resultString, out results))
                return results;

            return default(T);
        }

        protected string GetString(string url)
        {
            string resultString;
            using (var client = _auth.GetAuthenticatedWebClient())
            {
                resultString = client.DownloadString(url);
            }
            return resultString;
        }
    }
}
