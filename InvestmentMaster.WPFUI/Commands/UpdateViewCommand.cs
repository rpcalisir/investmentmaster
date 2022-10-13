using InvestmentMaster.WPFUI.Service;
using InvestmentMaster.WPFUI.ViewModels.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InvestmentMaster.WPFUI.Commands
{
    internal class UpdateViewCommand: ICommand
    {
        public event EventHandler CanExecuteChanged;

        private MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter.ToString() == "ComparisonFundReturnsView")
            {
                //viewModel.SelectedViewModel = new ComparisonFundReturnsModel();
                ComparisonFundReturnsModel comparisonFundReturnsViewModel = new ComparisonFundReturnsModel();
                viewModel.SelectedViewModel = comparisonFundReturnsViewModel;

                RefreshPortfolioService.RefreshPortfolioTable(comparisonFundReturnsViewModel);

            }
            else if (parameter.ToString() == "PortfolioView")
            {
                PortfolioViewModel portfolioViewModel = new PortfolioViewModel();
                viewModel.SelectedViewModel = portfolioViewModel;

                RefreshPortfolioService.RefreshPortfolioTable(portfolioViewModel);

                //MessageBox.Show("Portfolio Button is clicked");
            }
        }
    }
}
