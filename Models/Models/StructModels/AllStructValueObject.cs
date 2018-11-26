using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.StructModels
{
    public class AllStructValueObject
    {
        public string Name { get; set; }
        public Dictionary<int, AllStructValueObject> Descendants { get; set; }
    }
}
