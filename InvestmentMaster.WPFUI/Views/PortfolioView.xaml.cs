using InvestmentMaster.BL.Abstract;
using InvestmentMaster.BL.DependncyResolvers.Ninject;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InvestmentMaster.WPFUI.Views
{
    /// <summary>
    /// Interaction logic for PortfolioView.xaml
    /// </summary>
    public partial class PortfolioView : UserControl
    {
        //private readonly IPortfolioFundService _portfolioFundService;

        public PortfolioView()
        {
            InitializeComponent();

            //_portfolioFundService = InstanceFactory.GetInstance<IPortfolioFundService>();
        }

        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scrollViewer = (ScrollViewer)sender;
            if (e.Delta < 0)
            {
                scrollViewer.LineDown();
            }
            else
            {
                scrollViewer.LineUp();
            }
            e.Handled = true;
        }

        private void dgPortfolioView_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int zeroBasedIndex = Convert.ToInt32(e.Row.GetIndex().ToString());
            e.Row.Header = zeroBasedIndex + 1;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Fund fund = dgPortfolioView.SelectedItem as Fund;
            PortfolioFund selectedFund = new PortfolioFund
            {
                FONKODU = fund.FONKODU
            };

            using (FundContext fundContext = new FundContext())
            {
                if (fundContext.Set<PortfolioFund>().Any(f => f.FONKODU == selectedFund.FONKODU))
                {
                    var fundToRemove = fundContext.PortfolioFunds.SingleOrDefault(f => f.FONKODU == selectedFund.FONKODU);

                    if (fundToRemove != null)
                    {
                        fundContext.PortfolioFunds.Remove(fundToRemove);

                        //dgPortfolioView.DataContext = null;
                        //dgPortfolioView.ItemsSource = portfolioViewModel.Funds;
                        //dgPortfolioView.Items.Refresh();
                        //dgPortfolioView.UpdateLayout();
                    }

                    //fundContext.SavedFunds.Attach(selectedFund);
                    //fundContext.SavedFunds.Remove(selectedFund);    

                    MessageBox.Show($"{selectedFund.FONKODU} Portföy'den silindi!");

                    //var entity = fundContext.Portfolio.SingleOrDefault(f => f.FONKODU == selectedFund.FONKODU);
                    //if (entity != null)
                    //{
                    //    entity.FONKODU = selectedFund.FONKODU;
                    //}
                }
                else
                {
                    MessageBox.Show($"{selectedFund.FONKODU} Portföy'de mevcut değil!");
                }

                fundContext.SaveChanges();

                //RefreshPortfolioService.RefreshPortfolioTable(portfolioViewModel);
            }
        }
    }
}
