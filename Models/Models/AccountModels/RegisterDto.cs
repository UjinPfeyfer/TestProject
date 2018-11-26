using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Models.AccountModels
{
    
    public class RegisterDto
    {
        [Required]
        //[DataType(DataType.EmailAddress)]
        //[MaxLength (256)]
        public string Email { get; set; }

        [Required]
       // [StringLength(100, MinimumLength = 2, ErrorMessage = "Surname Should be minimum 2 characters and a maximum of 100 characters")]
        public string Name { get; set; }

        [Required]
       // [StringLength(100, MinimumLength = 2, ErrorMessage = "Name Should be minimum 2 characters and a maximum of 100 characters")]
        public string Surname { get; set; }

        [Required]
       // [StringLength(100, MinimumLength = 2, ErrorMessage = "Second Name Should be minimum 2 characters and a maximum of 100 characters")]
        public string SecondName { get; set; }

        [Required]
      //  [StringLength(100, MinimumLength = 2, ErrorMessage = "Subdivision Should be minimum 2 characters and a maximum of 100 characters")]
        public string Subdivision { get; set; }

        [Required]
      //  [Phone]
      //  [StringLength(100, MinimumLength = 2, ErrorMessage = "Position Should be minimum 2 characters and a maximum of 100 characters")]
        public string Position { get; set; }

        [Required]
      //  [StringLength(100, MinimumLength = 2, ErrorMessage = "Subdivision Should be minimum 2 characters and a maximum of 100 characters")]
        public string PhoneNumber { get; set; }

        //[Required]
        //public string Role { get; set; }

        public string GetPassword()
        {
            string password;
            do
            {
                password = GeneratePassword();
            }
            while (!Regex.IsMatch(password, @"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])"));
           return password;
             
        }

        private string GeneratePassword()
        {
            string password = "";
            for (int i = 0; i < 8; ++i)
            {
                password += NextChar();
            }
            return password.ToString();
        }

        private Char NextChar()
        {
            Random rand = new Random();
            int i;
            do
            {
                i = rand.Next(48, 122);
            }
            while (i > 57 && (i < 65 || i > 90) && i < 97);
            
            return (char)i;
        }
                
    }

    
}
