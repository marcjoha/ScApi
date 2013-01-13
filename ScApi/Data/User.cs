namespace ScApi.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Avatars Avatars { get; set; }
        public string Username { get; set; }
        public bool Terminated { get; set; }
        public bool Inactive { get; set; }
        public string Role { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
    }
}