using System.Collections.Generic;

namespace ScApi.Data
{
    public class ExternalResource
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CanonicalHashtag { get; set; }
        public string Type { get; set; }
        public Source Source { get; set; }
        public List<Tag> Tags { get; set; }
        public OEmbed OEmbed { get; set; }
        public List<MediaFile> MediaFiles { get; set; }
    }
}