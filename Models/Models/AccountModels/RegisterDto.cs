using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

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

        [Required]
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
