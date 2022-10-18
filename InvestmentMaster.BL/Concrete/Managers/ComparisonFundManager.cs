using InvestmentMaster.BL.Abstract;
using InvestmentMaster.Core.Entities;
using InvestmentMaster.DataAccess.Abstract;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.BL.Concrete.Managers
{
    public class ComparisonFundManager : IComparisonFundService
    {
        IComparisonFundDal _fundDal;

        public ComparisonFundManager(IComparisonFundDal fundDal)
        {
            _fundDal = fundDal;
        }

        public List<Fund> GetAllComparisonFunds(Expression<Func<Fund, bool>>? filter = null)
        {
            return _fundDal.GetAll(filter);
        }
    }
}
