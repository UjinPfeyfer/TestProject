using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class Country
    {
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public virtual List<Significative> Significatives { get; set; }

        //public Country()
        //{
        //    Significatives = new List<Significative>();
        //}
    }
}
