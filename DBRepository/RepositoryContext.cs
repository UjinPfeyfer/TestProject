using System;
using System.Collections.Generic;
using System.Text;
using Models.Models;
using Models.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace DBRepository
{
    public class RepositoryContext : IdentityDbContext<ApplicationUser>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }
        public DbSet<Data> Datas{ get; set;}

    }
}
