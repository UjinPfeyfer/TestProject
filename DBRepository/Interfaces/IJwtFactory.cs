using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models.Models;


namespace DBRepository.Interfaces
{
    public interface IJwtFactory
    {
        Task<object> GenerateJwtToken(string email, ApplicationUser user);
    }
}
