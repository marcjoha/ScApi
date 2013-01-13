using System.Collections.Generic;

namespace ScApi.Data
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public int MyResponseId { get; set; }
        public List<Answer> Answers { get; set; }
    }
}