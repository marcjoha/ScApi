namespace ScApi.Data
{
    public class Community
    {
        public string Name { get; set; }
        public string Subdomain { get; set; }
        public string Domain { get; set; }
        public UserProfile Profile { get; set; }
        public bool PrivateMessagesEnabled { get; set; }
        public bool AttachmentsEnabled { get; set; }
    }
}