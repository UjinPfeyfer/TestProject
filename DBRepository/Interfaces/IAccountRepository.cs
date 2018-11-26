using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Models.Models;
using Models.Models.AccountModels;
using Microsoft.AspNetCore.Identity;

namespace DBRepository.Interfaces
{
    public interface IAccountRepository
    {
        Task<ApplicationUser> GetUser(string userName);
        Task<SignInResult> LoginUser(LoginDto model);
        Task LoginUser(ApplicationUser user);
        Task<IdentityResult> CreateUser(ApplicationUser user, string password);
        Task<IdentityResult> ChangePassword(ApplicationUser user, string oldPassword, string newPassword);
        //Task<IdentityResult> ChangePassword(ApplicationUser user, string newPassword);
    }
}
