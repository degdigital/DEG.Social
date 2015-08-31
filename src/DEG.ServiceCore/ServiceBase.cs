using System;
using System.Net;
using DEG.ServiceCore.Authentication;
using DEG.ServiceCore.Helpers;
using DEG.ServiceCore.Models;

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
                resultString = client.DownloadString(_auth.GetAuthenticatedUrl(url));
            }
            return resultString;
        }

        public TResp SubmitObject<TResp, TReq>(string url, TReq request, DataFormat format = DataFormat.Json) where TResp : class
        {
            var contentType = format == DataFormat.Xml ? "application/xml" : "application/json";
            var resultString = SubmitString(url, request, contentType);

            TResp results;
            if (JsonHelper.TryParse(resultString, out results))
                return results;
            if (XmlHelper.TryParse(resultString, out results))
                return results;

            return default(TResp);
        }

        protected string SubmitString<TReq>(string url, TReq request, string contentType)
        {
            string resultString;
            using (var client = _auth.GetAuthenticatedWebClient())
            {
                var requestString = contentType.Equals("application/xml", StringComparison.InvariantCultureIgnoreCase)
                                           ? XmlHelper.Stringify(request)
                                           : JsonHelper.Stringify(request);

                client.Headers.Add(HttpRequestHeader.ContentType, contentType);
                resultString = client.UploadString(_auth.GetAuthenticatedUrl(url), requestString);
            }
            return resultString;
        }
    }
}
