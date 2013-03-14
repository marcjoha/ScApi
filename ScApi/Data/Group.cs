using System.Collections.Generic;

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
        public List<int> AdminIds { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Permission { get; set; }
        public string GroupType { get; set; }
    }
}