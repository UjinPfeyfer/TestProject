using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using Models.Models.AccountModels;
using ChildrenPortal.Services.Interfaces;

namespace ChildrenPortal.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;

        public AccountController(
            IAccountService service
            )
        {
            _service = service;
        }

        public async Task<object> Login([FromBody] LoginDto model)
        {
            var result = await _service.LoginUser(model);

            if (result.Succeeded)
            {
                var appUser = await _service.GetUser(model.Email);
                return await _service.GenerateToken(model.Email, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }

        [HttpPost]
        public async Task<object> Register([FromBody] RegisterDto model)
        {
            var user = new ApplicationUser
            {
                Name = model.Name,
                Surname = model.Surname,
                SecondName = model.SecondName,
                Subdivision = model.Subdivision,
                Position = model.Position,
                Email = model.Email,
                UserName = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            var result =await _service.CreateUser(user, model.GetPassword());

            if (result.Succeeded)
            {
                await _service.LoginUser(user);
                return await _service.GenerateToken(model.Email, user);
            }

            throw new ApplicationException("UNKNOWN_ERROR");
        } 
    }
}