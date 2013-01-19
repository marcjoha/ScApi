namespace ScApi.Data
{
    public class Stream
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool NewUpdates { get; set; }
        public bool Default { get; set; }
        public bool CustomStream { get; set; }
        public int LastInteractedAt { get; set; }
    }
}