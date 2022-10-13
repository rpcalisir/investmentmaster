using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.WPFUI.ViewModels.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.WPFUI.Service
{
    public class RefreshPortfolioService
    {
        public static void RefreshPortfolioTable(BaseViewModel portfolioViewModel)
        {
            //PortfolioView portfolioView = new PortfolioView();
            //portfolioView.dgPortfolioView.DataContext = null;

            //using (FundContext fundContext = new FundContext())
            //{
            //    List<SelectedFund> selectedFunds = new List<SelectedFund>();
            //    selectedFunds = fundContext.SavedFunds.ToList();
            //    var fundCodes = selectedFunds.Select(f => f.FONKODU).ToList();
            //    portfolioView.dgPortfolioView.DataContext = fundContext.Funds.Where(f => fundCodes.Contains(f.FONKODU)).ToList();
            //}

            //portfolioView.dgPortfolioView.DataContext = portfolioViewModel.Funds;
            //portfolioView.dgPortfolioView.Items.Refresh();
            //portfolioView.dgPortfolioView.UpdateLayout();
        }
    }
}
