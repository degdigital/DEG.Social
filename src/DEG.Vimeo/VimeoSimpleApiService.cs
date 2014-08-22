using System.Collections.Generic;
using System.Web;
using DEG.ServiceCore;
using DEG.ServiceCore.Authentication;
using DEG.Vimeo.Models;

namespace DEG.Vimeo
{
    public interface IVimeoSimpleApiService
    {
        IEnumerable<Video> GetAlbumVideos(string albumId);
    }

    public class VimeoSimpleApiService : ServiceBase, IVimeoSimpleApiService
    {
        private const string BaseUrl = "http://vimeo.com/api/v2";

        public VimeoSimpleApiService() : base(new NoAuthentication()) { }

        public IEnumerable<Video> GetAlbumVideos(string albumId)
        {
            var url = BaseUrl + "/album/" + HttpUtility.UrlEncode(albumId) + "/videos.json";
            return GetObject<IEnumerable<Video>>(url);
        }
    }
}
