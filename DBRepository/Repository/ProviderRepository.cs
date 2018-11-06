using System;
using System.Collections.Generic;
using System.Text;
using DBRepository.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Models.Models;

namespace DBRepository.Repository
{
    class ProviderRepository:BaseRepository, IProviderRepository
    {
        RepositoryContext pr;
        private UserManager<ApplicationUser> UserManager { get; }
        private SignInManager<ApplicationUser> SignInManager { get; }
        public ProviderRepository(string connectionString, IRepositoryContextFactory contextFactory)
        {
            using (var context = ContextFactory.CreateDbContext(ConnectionString))
            {
                UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            https://habr.com/company/microsoft/blog/279985/
            }
        }
    }
}
