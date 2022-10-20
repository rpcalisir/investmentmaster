﻿using InvestmentMaster.BL.Abstract;
using InvestmentMaster.BL.DependncyResolvers.Ninject;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.Entities.Concrete;
using InvestmentMaster.WPFUI.ViewModels.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ComparisonFundReturnsView.xaml
    /// </summary>
    public partial class ComparisonFundReturnsView : UserControl
    {
        //ObservableCollection<Fund> Funds;
        private IComparisonFundService _comparisonFundService;

        public ComparisonFundReturnsView()
        {
            InitializeComponent();

            //Funds = new ObservableCollection<Fund>(ComparisonFundReturnsModel.Funds);
            //Funds = ComparisonFundReturnsModel.Funds;

            //this.dgComparisonFundReturnView.ItemsSource = ComparisonFundReturnsModel.Funds;

            _comparisonFundService = InstanceFactory.GetInstance<IComparisonFundService>();

            this.dgComparisonFundReturnView.ItemsSource = _comparisonFundService.GetAllComparisonFunds();
        }

        private void tbSearchFund_KeyUp(object sender, KeyEventArgs e)
        {
            //using (FundContext fundContext = new FundContext())
            //{
            //    var filtered = fundContext.Funds.ToList().Where(f => f.FONKODU.StartsWith(tbSearchFund.Text, StringComparison.InvariantCultureIgnoreCase));
            //    dgComparisonFundReturnView.ItemsSource = filtered;
            //}

            var filtered = _comparisonFundService.GetAllComparisonFunds().ToList().Where(f => f.FONKODU.StartsWith(tbSearchFund.Text,
                StringComparison.InvariantCultureIgnoreCase) || f.FONUNVAN.StartsWith(tbSearchFund.Text, StringComparison.InvariantCultureIgnoreCase));
            dgComparisonFundReturnView.ItemsSource = filtered;
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

        private void dgComparisonFundReturnView_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int zeroBasedIndex = Convert.ToInt32((e.Row.GetIndex()).ToString());
            e.Row.Header = zeroBasedIndex + 1;
        }

        private void btnAddClick(object sender, RoutedEventArgs e)
        {
            Fund fund = dgComparisonFundReturnView.SelectedItem as Fund;
            PortfolioFund selectedFund = new PortfolioFund();
            selectedFund.FONKODU = fund.FONKODU;

            using (FundContext fundContext = new FundContext())
            {
                if (fundContext.Set<PortfolioFund>().Any(f => f.FONKODU == selectedFund.FONKODU))
                {
                    MessageBox.Show($"{selectedFund.FONKODU} Portföy'de mevcut!");

                    //var entity = fundContext.Portfolio.SingleOrDefault(f => f.FONKODU == selectedFund.FONKODU);
                    //if (entity != null)
                    //{
                    //    entity.FONKODU = selectedFund.FONKODU;
                    //}
                }
                else
                {
                    fundContext.Entry(selectedFund).State = EntityState.Added;
                    MessageBox.Show($"{selectedFund.FONKODU} fonu Portföy'e eklendi!");
                }

                fundContext.SaveChanges();
            }
        }
    }
}
