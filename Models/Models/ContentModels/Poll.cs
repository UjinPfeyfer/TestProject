using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.ContentModels
{
    public class Poll
    {
        public int PollId { get; set; }
        public string Header { get; set; }
        public DateTime CreatingTime { get; set; }
        public DateTime UpdatingTime { get; set; }
        public int IntervieweeCount { get; set; }
        public string CreatorId { get; set; }
        public ApplicationUser Creator { get; set; }
        public string Question { get; set; }
        public List<PollAnswer> Answers { get; set; }

        public Poll()
        {
            Answers = new List<PollAnswer>();
        }
    }
}
