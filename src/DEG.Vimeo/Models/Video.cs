using System;
using System.Runtime.Serialization;

namespace DEG.Vimeo.Models
{
    [DataContract]
    public class Video
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "url")]
        public string Url { get; set; }
        [DataMember(Name = "id")]
        public string Id { get; set; }
        [DataMember(Name = "description")]
        public string Description { get; set; }
        [DataMember(Name = "tags")]
        public string Tags { get; set; }
        [DataMember(Name = "upload_date")]
        public string UploadDateRaw { get; set; }
        public DateTime? UploadDate
        {
            get
            {
                DateTime parsed;
                if (DateTime.TryParse(UploadDateRaw, out parsed))
                    return parsed;
                return null;
            }
            set { UploadDateRaw = value.ToString(); }
        }

        [DataMember(Name = "thumbnail_small")]
        public string ThumbnailSmall { get; set; }
        [DataMember(Name = "thumbnail_medium")]
        public string ThumbnailMedium { get; set; }
        [DataMember(Name = "thumbnail_large")]
        public string ThumbnailLarge { get; set; }

        [DataMember(Name = "user_name")]
        public string UserName { get; set; }
        [DataMember(Name = "user_url")]
        public string UserUrl { get; set; }
        [DataMember(Name = "user_portrait_small")]
        public string UserPortraitSmall { get; set; }
        [DataMember(Name = "user_portrait_medium")]
        public string UserPortraitMedium { get; set; }
        [DataMember(Name = "user_portrait_large")]
        public string UserPortraitLarge { get; set; }

        [DataMember(Name = "stats_number_of_likes")]
        public int NumberOfLikes { get; set; }
        [DataMember(Name = "stats_number_of_plays")]
        public int NumberOfPlays { get; set; }
        [DataMember(Name = "stats_number_of_comments")]
        public int NumberOfComments { get; set; }
    }
}
