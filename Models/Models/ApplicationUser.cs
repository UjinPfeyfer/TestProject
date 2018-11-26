using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        public string Subdivision { get; set; }
        [Required]
        public string Position { get; set; }
        public bool IsNeedChangePassword { get; set; }



    }
}
