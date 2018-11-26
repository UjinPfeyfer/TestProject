using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;
using Models.Models.AccountModels;
using Microsoft.AspNetCore.Identity;

namespace ChildrenPortal.Services.Interfaces
{
    public interface IAccountService
    {
        Task<ApplicationUser> GetUser(string userName);
        Task<SignInResult> LoginUser(LoginDto model);
        Task LoginUser(ApplicationUser user);
        Task<IdentityResult> CreateUser(ApplicationUser user, string password);
        Task<Object> GenerateToken(string email, ApplicationUser user);
    }
}
