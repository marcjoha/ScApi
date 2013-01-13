using System;

namespace ScApi.Data
{
    public class Like
    {
        public string Id { get; set; }
        public User User { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool Unlikable { get; set; }
    }
}