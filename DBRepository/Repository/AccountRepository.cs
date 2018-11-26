using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Models.Models;
using Models.Models.AccountModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DBRepository.Repository
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        protected SignInManager<ApplicationUser> SignInManager { get; }
        protected UserManager<ApplicationUser> UserManager { get; }

        public AccountRepository(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            : base()
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public async Task<ApplicationUser> GetUser(string userName)
        {
                return await UserManager.Users.FirstOrDefaultAsync(u => u.Email == userName);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> LoginUser(LoginDto model)
        {
            //ApplicationUser user = await GetUser(model.Email);
            //if (await UserManager.CheckPasswordAsync(user, model.Password) && user.IsNeedChangePassword)
            //    return  
                return await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }

        public async Task LoginUser(ApplicationUser user)
        { 
            await SignInManager.SignInAsync(user, false);
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            user.IsNeedChangePassword = true;
            return await UserManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> EditUser(ApplicationUser user)
        {
            return await UserManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> ChangePassword(ApplicationUser user, string oldPassword, string newPassword)
        {
            if (UserManager.ChangePasswordAsync(user, oldPassword, newPassword).Result.Succeeded)
            {
                user.IsNeedChangePassword = false;
                return await UserManager.UpdateAsync(user);
            }
            throw new NotImplementedException();
        }

        private async Task<IdentityResult> ChangePassword(ApplicationUser user, string newPassword)
        {
            if (UserManager.ResetPasswordAsync(user, await UserManager.GeneratePasswordResetTokenAsync(user), newPassword).Result.Succeeded)
            {
                user.IsNeedChangePassword = true;
                return await UserManager.UpdateAsync(user);
            }
            throw new NotImplementedException();
        }
    }

}
