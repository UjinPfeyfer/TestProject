using System;
using System.Collections.Generic;
using System.Text;
using DBRepository.Interfaces;

namespace DBRepository.Repository
{
    public class ChildrenPortalRepository : BaseRepository, IChildrenPortalRepository
    {
        public ChildrenPortalRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

        

    }
}
