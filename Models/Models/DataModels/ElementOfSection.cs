using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class ElementOfSection
    {
        public int ElementOfSectionId { get; set; }
        public string ElementOfSectionName { get; set; }
        public int SectionId { get; set; }
        public virtual Section Section { get; set; }
        public virtual List<ElementOfSectionSignificate> ElementOfSectionSignificates { get; set; }

        //public ElementOfSection()
        //{
        //    ElementOfSectionSignificates = new List<ElementOfSectionSignificate>();
        //}
    }
}
