namespace ScApi.Data
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
        public Avatars Avatars { get; set; }
        public string Username { get; set; }
        public string Groupname { get; set; }
        public bool Private { get; set; }
    }
}