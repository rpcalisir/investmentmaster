using InvestmentMaster.Core.Entities;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.BL.Abstract
{
    public interface IComparisonFundService
    {
        List<Fund> GetAllComparisonFunds(Expression<Func<Fund, bool>>? filter = null);
    }
}
