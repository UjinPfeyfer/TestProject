using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class ElementOfSectionSignificate
    {
        public int ElementOfSectionSignificateId { get; set; }
        public int ElementOfSectionId { get; set; }
        public virtual ElementOfSection ElementOfSection { get; set; }
        public int SignificativeId { get; set; }
        public virtual Significative Significative { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public float Count { get; set; }
    }
}
