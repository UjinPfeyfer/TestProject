using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class Significative
    {
        public int SignificativeId { get; set; }
        public string SignificativeName { get; set; }
        public int SubheadingId { get; set; }
        public virtual Subheading Subheading { get; set; }
        public virtual List<ElementOfSectionSignificate> ElementOfSectionSignificates { get; set; }
        //public Significative()
        //{
        //    ElementOfSectionSignificates = new List<ElementOfSectionSignificate>();
        //}
    }
}
