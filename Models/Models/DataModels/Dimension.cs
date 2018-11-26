using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class Dimension
    {
        public int DimensionId { get; set; }
        public string DimensionName { get; set; }
        public virtual List<DimensionTree> DimensionTrees { get; set; }
        //public int ParentId { get; set; }
        //public virtual DimensionTable DimensionTable { get; set; }
    }
}
