using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Models.Models;

namespace DBRepository.Interfaces
{
        public interface IProviderRepository : IDisposable
        {
            UserManager<ApplicationUser> UserManager { get; }
            SignInManager<ApplicationUser> SingInManager { get; }
        }
    }

