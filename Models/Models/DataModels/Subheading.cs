using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class Subheading
    {
        public int SubheadingId { get; set; }
        public string SubheadingName { get; set; }
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }
        public virtual List<Significative> Significatives { get; set; }
        //public Subheading()
        //{
        //    Significatives = new List<Significative>();
        //}
    }
}
