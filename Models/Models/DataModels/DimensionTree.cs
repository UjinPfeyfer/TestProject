using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.DataModels
{
    public class DimensionTree
    {
        public int DimensionTreeId { get; set; }
        public int DimensionId { get; set; }
        public virtual Dimension Dimension { get; set; }
        public int DescendantId { get; set; }
        public int Level { get; set; }
        public int ParentId { get; set; }
    }
}
