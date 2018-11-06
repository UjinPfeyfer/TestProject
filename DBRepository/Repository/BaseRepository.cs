using System;
using System.Collections.Generic;
using System.Text;
using DBRepository.Interfaces;
using Models.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace DBRepository.Repository
{
    public abstract class BaseRepository
    {
        protected string ConnectionString { get; }
        protected IRepositoryContextFactory ContextFactory { get; }
        

        public BaseRepository(string connectionString, IRepositoryContextFactory contextFactory)
        {
            ConnectionString = connectionString;
            ContextFactory = contextFactory;
        }

        public BaseRepository()
        {

        }
    }
}
