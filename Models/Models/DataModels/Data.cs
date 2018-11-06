using System;
using System.Collections.Generic;
using System.Text;
//using Models.Models;

namespace Models.Models.DataModels
{
    public class Data
    {
        public int Id { get; set; }
        public string DataForm { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
