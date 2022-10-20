using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.BL.Abstract
{
    public interface IPortfolioFundService
    {
        List<Fund> GetAllPortfolioFunds();
        List<PortfolioFund> GetAllPortfolioFundCodes();
        PortfolioFund AddPortfolioFund(PortfolioFund portfolioFund);
        PortfolioFund DeletePortfolioFund(PortfolioFund portfolioFund);
    }
}
