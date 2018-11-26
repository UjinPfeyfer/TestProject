using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Models.StructModels
{
    public class UpdateStructNameParent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
    }
}