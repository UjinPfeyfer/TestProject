using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChildrenPortal.Services.Interfaces;
using DBRepository.Interfaces;
using Models.Models;
using Models.Models.AccountModels;
using Microsoft.AspNetCore.Identity;

namespace ChildrenPortal.Services.Implementation
{
    public class AccountService : IAccountService
    {
        IAccountRepository _repository;
        IJwtFactory _jwtFactory;
        public AccountService(IAccountRepository repository, IJwtFactory jwtFactory)
        {
            _repository = repository;
            _jwtFactory = jwtFactory;
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

        public async Task<Object> GenerateToken(string email, ApplicationUser user)
        {
            return await _jwtFactory.GenerateJwtToken(email, user);
        }



    }
}
