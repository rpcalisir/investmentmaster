using InvestmentMaster.BL.Abstract;
using InvestmentMaster.BL.Concrete.Managers;
using InvestmentMaster.BL.DependncyResolvers.Ninject;
using InvestmentMaster.DataAccess.API;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.DataAccess.Utilities;
using InvestmentMaster.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.WPFUI.ViewModels.Concrete
{
    public class ComparisonFundReturnsModel : BaseViewModel
    {
        //private readonly IComparisonFundService _comparisonFundService;
        //private readonly IPortfolioFundService _portfolioFundService;

        //public IComparisonFundService ComparisonFundService { get; private set; }
        //public IPortfolioFundService PortfolioFundService { get; private set; }

        private IComparisonFundService _comparisonFundService;

        public IComparisonFundService ComparisonFundService
        {
            get { return _comparisonFundService; }
            set { _comparisonFundService = value; }
        }

        private IPortfolioFundService _portfolioFundService;

        public IPortfolioFundService PortfolioFundService
        {
            get { return _portfolioFundService; }
            set { _portfolioFundService = value; }
        }

        public ObservableCollection<Fund> ComparisonFunds { get; private set; }
        public ObservableCollection<Fund> PortfolioFunds { get; private set; }

        //private IComparisonFundService _comparisonFundService;

        //private static IComparisonFundService _comparisonFundService;

        //public static IComparisonFundService ComparisonFundService
        //{
        //    get { return _comparisonFundService; }
        //    set { _comparisonFundService = value; }
        //}


        public ComparisonFundReturnsModel()
        {
            //ComparisonFundManager fundManager = new ComparisonFundManager(new EfComparisonFundDal());

            //_comparisonFundService = InstanceFactory.GetInstance<IComparisonFundService>();

            _comparisonFundService = InstanceFactory.GetInstance<IComparisonFundService>();
            _portfolioFundService = InstanceFactory.GetInstance<IPortfolioFundService>();

            ComparisonFunds = new ObservableCollection<Fund>(_comparisonFundService.GetAllComparisonFunds());
            PortfolioFunds = new ObservableCollection<Fund>(_portfolioFundService.GetAllPortfolioFunds());
        }

        public void AddPortfolioFund(PortfolioFund portfolioFund)
        {
            _portfolioFundService.AddPortfolioFund(portfolioFund);
        }
    }
}
