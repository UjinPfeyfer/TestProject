using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class Section
    {
        public int SectionId { get; set; }
        public string SectionName { get; set; }
        public virtual List<ElementOfSection> ElementOfSections { get; set; }
        //public Section()
        //{
        //    ElementOfSections = new List<ElementOfSection>();
        //}
    }
}
