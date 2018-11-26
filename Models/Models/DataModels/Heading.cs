using System;
using System.Collections.Generic;
using System.Text;
//using Models.Models;

namespace Models.Models.DataModels
{
    public class Heading
    {
        public int HeadingId { get; set; }
        public string HeadingName { get; set; }
        public virtual List<Subheading> Subheadings { get; set; }
        //public Heading()
        //{
        //    Subheadings = new List<Subheading>();
        //}
    }
}
