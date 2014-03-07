using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DEG.YouTube.Models
{
    [DataContract]
    public class PlaylistItemsResults
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "etag")]
        public string Etag { get; set; }
        [DataMember(Name = "nextPageToken")]
        public string NextPageToken { get; set; }
        [DataMember(Name = "prevPageToken")]
        public string PrevPageToken { get; set; }
        [DataMember(Name = "pageInfo")]
        public PageInfo PageInfo { get; set; }
        [DataMember(Name = "items")]
        public IEnumerable<PlaylistItem> Items { get; set; }
    }

    [DataContract]
    public class PlaylistItem
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "etag")]
        public string Etag { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "snippet")]
        public PlaylistItemSnippet Snippet { get; set; }
        [DataMember(Name = "status")]
        public PlaylistItemStatus Status { get; set; }
        [DataMember(Name = "contentDetails")]
        public PlaylistItemContentDetails ContentDetails { get; set; }
    }

    [DataContract]
    public class PlaylistItemContentDetails
    {
        [DataMember(Name = "videoId")]
        public string VideoId { get; set; }
    }

    [DataContract]
    public class PlaylistItemStatus
    {
        [DataMember(Name = "privacyStatus")]
        public string PrivacyStatus { get; set; }
    }

    [DataContract]
    public class PlaylistItemSnippet
    {
        [DataMember(Name = "publishedAt")]
        public string PublishedAtRaw { get; set; }
        public DateTime? Published
        {
            get
            {
                DateTime parsed;
                if (DateTime.TryParse(PublishedAtRaw, out parsed))
                    return parsed;
                return null;
            }
            set { PublishedAtRaw = value.ToString(); }
        }

        [DataMember(Name = "channelId")]
        public string ChannelId { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "thumbnails")]
        public PlaylistItemSnippetThumbnails Thumbnails { get; set; }
        [DataMember(Name = "channelTitle")]
        public string ChannelTitle { get; set; }
        [DataMember(Name = "playlistId")]
        public string PlaylistId { get; set; }
        [DataMember(Name = "position")]
        public int? Position { get; set; }
        [DataMember(Name = "resourceId")]
        public PlaylistItemSnippetResourceId ResourceId { get; set; }
    }

    [DataContract]
    public class PlaylistItemSnippetResourceId
    {
        [DataMember(Name = "kind")]
        public string Kind { get; set; }
        [DataMember(Name = "videoId")]
        public string VideoId { get; set; }
    }

    [DataContract]
    public class PlaylistItemSnippetThumbnails
    {
        [DataMember(Name = "default")]
        public PlaylistItemSnippetThumbnail Default { get; set; }
        [DataMember(Name = "medium")]
        public PlaylistItemSnippetThumbnail Medium { get; set; }
        [DataMember(Name = "high")]
        public PlaylistItemSnippetThumbnail High { get; set; }
        [DataMember(Name = "standard")]
        public PlaylistItemSnippetThumbnail Standard { get; set; }
        [DataMember(Name = "maxres")]
        public PlaylistItemSnippetThumbnail MaximumResolution { get; set; }
    }

    [DataContract]
    public class PlaylistItemSnippetThumbnail
    {
        [DataMember(Name = "url")]
        public string Url { get; set; }
    }

    [DataContract]
    public class PageInfo
    {
        [DataMember(Name = "totalResults")]
        public int? TotalResults { get; set; }
        [DataMember(Name = "resultsPerPage")]
        public int? ResultsPerPage { get; set; }
    }
}
