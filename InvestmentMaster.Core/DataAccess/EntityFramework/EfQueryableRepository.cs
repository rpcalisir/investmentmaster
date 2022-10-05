using InvestmentMaster.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.Core.DataAccess.EntityFramework
{
    public class EfQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private DbContext _context;
        private DbSet<T>? _entities;

        public EfQueryableRepository(DbContext context)
        {
            _context = context;
        }

        public IQueryable<T> Table => this._entities;

        protected virtual DbSet<T> Entities 
        {
            get
            {
                return _entities ??= _context.Set<T>();
            }
        }

    }
}
