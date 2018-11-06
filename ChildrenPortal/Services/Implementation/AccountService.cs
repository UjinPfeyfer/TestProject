using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenPortal.Services.Interfaces;
using DBRepository.Interfaces;
using Models.Models;
using Microsoft.AspNetCore.Identity;

namespace ChildrenPortal.Services.Implementation
{
    public class AccountService : IAccountService
    {
        IAccountRepository _repository;
        public AccountService(IAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<ApplicationUser> GetUser(string userEmail)
        {
            return await _repository.GetUser(userEmail);
        }

        public async Task<SignInResult> LoginUser(LoginDto model)
        {
            return await _repository.LoginUser(model);
        }

        public async Task LoginUser(ApplicationUser user)
        {
            await _repository.LoginUser(user);
        }

        public async Task<IdentityResult> CreateUser(ApplicationUser user, string password)
        {
            return await _repository.CreateUser(user, password);
        }
        

    }
}
