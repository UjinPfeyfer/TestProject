using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.ContentModels
{
    public class News
    {
        public int NewsId { get; set; }
        public string Header { get; set; }
        public DateTime CreatingTime { get; set; }
        public DateTime UpdatingTime { get; set; }
        public string NewsText { get; set; }
    }
}
