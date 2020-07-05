using Core.Repositories;
using Data;
using Domain.Models;
using Repository.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        private readonly SQLContext _context;

        public RepositoryUser(SQLContext context) : base(context)
        {
            _context = context;
        }
    }
}
