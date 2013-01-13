namespace ScApi.Data
{
    public class OEmbed
    {
        public string Version { get; set; }
        public string ProviderName { get; set; }
        public string ProviderUrl { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string ThumbnailUrl { get; set; }
        public int ThumbnailWidth { get; set; }
        public int ThumbnailHeight { get; set; }
    }
}