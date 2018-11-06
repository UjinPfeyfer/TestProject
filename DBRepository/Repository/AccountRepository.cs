using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Models.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DBRepository.Repository
{
    public class AccountRepository : BaseRepository, IAccountRepository
    {
        protected SignInManager<ApplicationUser> SignInManager { get; }
        protected UserManager<ApplicationUser> UserManager { get; }

        public AccountRepository([FromServices]SignInManager<ApplicationUser> signInManager, [FromServices] UserManager<ApplicationUser> userManager)
            : base()
        {
            SignInManager = signInManager;
            UserManager = userManager;
        }
        public async Task<ApplicationUser> GetUser(string userName)
        {
                return await UserManager.Users.FirstOrDefaultAsync(u => u.Email == userName);
        }

        public async Task<Microsoft.AspNetCore.Identity.SignInResult> LoginUser(LoginDto model)
        {
            return await SignInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
        }

        public async Task LoginUser(ApplicationUser user)
        {
            await SignInManager.SignInAsync(user, false);
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            return await UserManager.CreateAsync(user, password);
        }
    }

}
