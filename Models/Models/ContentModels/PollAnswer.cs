using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.ContentModels
{
    public class PollAnswer
    {
        public int PollAnswerId { get; set; }
        public string PollAnswerText { get; set; }
        public int PollId { get; set; }
        public Poll Poll { get; set; }
        public bool IsAnswerRight { get; set; }
    }
}
