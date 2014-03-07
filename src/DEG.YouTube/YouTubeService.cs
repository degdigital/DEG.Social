using System.Web;
using DEG.ServiceCore;
using DEG.ServiceCore.Authentication;
using DEG.YouTube.Models;

namespace DEG.YouTube
{
    public interface IYouTubeService
    {
        PlaylistItemsResults GetPlaylistItems(string playlistId, int? pageSize = null, string pageToken = null);
    }

    public class YouTubeService : ServiceBase, IYouTubeService
    {
        private const string BaseUrl = "https://www.googleapis.com/youtube/v3";

        public YouTubeService(IServiceAuth auth) : base(auth) { }

        public PlaylistItemsResults GetPlaylistItems(string playlistId, int? pageSize = null, string pageToken = null)
        {
            var url = BaseUrl + "/playlistItems" +
                      "?part=" + HttpUtility.UrlEncode("id,snippet,contentDetails,status") +
                      "&playlistId=" + HttpUtility.UrlEncode(playlistId);

            if (pageSize.GetValueOrDefault(0) > 0)
                url += "&maxResults=" + pageSize;

            if (!string.IsNullOrEmpty(pageToken))
                url += "&pageToken=" + pageToken;

            return GetObject<PlaylistItemsResults>(url);
        }
    }
}
