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
    public class PortfolioFundManager : IPortfolioFundService
    {
        private readonly IPortfolioFundDal _portfolioFundDal;
        private readonly IComparisonFundDal _comparisonFundDal;

        public PortfolioFundManager(IPortfolioFundDal portfolioFundDal, IComparisonFundDal comparisonFundDal)
        {
            _portfolioFundDal = portfolioFundDal;
            _comparisonFundDal = comparisonFundDal;
        }

        public List<Fund> GetAllPortfolioFunds()
        {
            var fundCodes = _portfolioFundDal.GetAll().Select(f => f.FONKODU).ToList();

            return _comparisonFundDal.GetAll(f => fundCodes.Contains(f.FONKODU)).ToList();
        }

        public List<PortfolioFund> GetAllPortfolioFundCodes()
        {
            return _portfolioFundDal.GetAll();
        }

        public PortfolioFund AddPortfolioFund(PortfolioFund portfolioFund)
        {
            return _portfolioFundDal.Add(portfolioFund);
        }

        public PortfolioFund DeletePortfolioFund(PortfolioFund portfolioFund)
        {
            return _portfolioFundDal.Delete(portfolioFund);
        }
    }
}
