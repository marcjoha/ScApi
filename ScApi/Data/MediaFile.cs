namespace ScApi.Data
{
    public class MediaFile
    {
        public string Title { get; set; }
        public Thumbnails Thumbnails { get; set; }
        public string PageUrl { get; set; }
        public string Url { get; set; }
        public string ContentType { get; set; }
        public int AttachmentId { get; set; }
    }
}