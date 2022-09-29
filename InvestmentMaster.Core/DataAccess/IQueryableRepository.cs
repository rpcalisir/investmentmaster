using InvestmentMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.Core.DataAccess
{
    public  interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        public IQueryable<T> Table { get; }
    }
}
