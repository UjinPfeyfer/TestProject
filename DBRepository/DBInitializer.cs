using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DBRepository
{
    public static class DbInitializer
    {
        public async static Task Initialize(RepositoryContext context)
        {
            await context.Database.MigrateAsync();
        }
    }
}
