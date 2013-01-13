using System;
using System.Collections.Generic;

namespace ScApi.Data
{
    public class Message
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Action { get; set; }
        public string Verb { get; set; }
        public string MessageType { get; set; }
        public string Icon { get; set; }
        public string Url { get; set; }
        public string PermalinkUrl { get; set; }
        public string ExternalUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public List<Like> Likes { get; set; }
        public int LikesCount { get; set; }
        public List<Comment> Comments { get; set; }
        public int CommentsCount { get; set; }
        public List<Attachment> Attachments { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
        public bool ContainsUrlOnly { get; set; }
        public List<ExternalResource> ExternalResources { get; set; }
        public List<Tag> Tags { get; set; }
        public int LastInteractedAt { get; set; }
        public Group Group { get; set; }
        public string CategoryId { get; set; }
        public List<Recipient> Recipients { get; set; }
        public string ThumbnailUrl { get; set; }
        public string PlayerUrl { get; set; }
        public string PlayerParams { get; set; }
        public bool Likable { get; set; }
        public bool Ratable { get; set; }
        public string Rating { get; set; }
        public string RatingsAverage { get; set; }
        public string RatingsCount { get; set; }
        public bool Editable { get; set; }
        public bool Deletable { get; set; }
        public bool Watchable { get; set; }
        public string Watch { get; set; }
        public string Flag { get; set; }
        public Source Source { get; set; }
        public Poll Poll { get; set; }
        public string Embed { get; set; }
        public string Hidden { get; set; }
        public string Subscribed { get; set; }
        public List<Group> Groups { get; set; }
        public List<string> Extensions { get; set; }
        public string NewGroupId { get; set; }
    }
}