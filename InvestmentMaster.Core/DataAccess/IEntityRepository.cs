﻿using InvestmentMaster.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.Core.DataAccess
{
    /// <summary>
    /// Contract to specify common methods for data access operations.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        List<T> GetAll(Expression<Func<T, bool>>? filter = null);

        T Get(Expression<Func<T, bool>> filter);

        T Add(T entity);
        T Update(T entity);
        T Delete(T entity);
    }
}
