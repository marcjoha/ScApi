using System.Collections.Generic;

namespace ScApi.Data
{
    public class UserProfile
    {
        public ContactInfo ContactInfo { get; set; }
        public User Manager { get; set; }
        public List<CustomField> CustomFields { get; set; }
        public bool Followable { get; set; }
        public int ContactId { get; set; }
        public int FollowingCount { get; set; }
        public int FollowersUsers { get; set; }
        public string StatusMessage { get; set; }
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