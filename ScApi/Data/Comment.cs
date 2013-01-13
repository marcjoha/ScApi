using System;
using System.Collections.Generic;

namespace ScApi.Data
{
    public class Comment
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public User User { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Attachment> Attachments { get; set; }
        public string ThumbnailUrl { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        public string PermalinkUrl { get; set; }
        public bool Editable { get; set; }
        public bool Deletable { get; set; }
        public bool Likable { get; set; }
        public List<Like> Likes { get; set; }
        public int LikesCount { get; set; }
    }
}