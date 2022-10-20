using InvestmentMaster.BL.Abstract;
using InvestmentMaster.BL.Concrete.Managers;
using InvestmentMaster.BL.DependncyResolvers.Ninject;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.Entities.Concrete;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.WPFUI.ViewModels.Concrete
{
    public class PortfolioViewModel: BaseViewModel
    {
        //public static List<Fund> Funds;
        //public static ObservableCollection<Fund> Funds { get; }

        private readonly IPortfolioFundService _portfolioFundService;
        private DelegateCommand<Fund> _deletePortfolioFundCommand;
        private ObservableCollection<Fund> _funds;

        public ObservableCollection<Fund> Funds
        {
            get
            {
                return _funds;
            }
            set
            {
                _funds = value;
                OnPropertyChanged(nameof(Funds));
            }
        }

        public PortfolioViewModel()
        {
            _portfolioFundService = InstanceFactory.GetInstance<IPortfolioFundService>();
            //List<SelectedFund> selectedFunds = new List<SelectedFund>();

            //using (FundContext fundContext = new FundContext())
            //{
            //    selectedFunds = fundContext.PortfolioFunds.ToList();
            //    var fundCodes = selectedFunds.Select(f => f.FONKODU).ToList();

            //    //var fundCodes = selectedFunds.Select(f => f.FONKODU).Intersect(fundContext.Funds.ToList().Select(x => x.FONKODU)).ToList();
            //    Funds = new ObservableCollection<Fund>(fundContext.ComparisonFunds.Where(f => fundCodes.Contains(f.FONKODU)).ToList());

            //    //Funds = new ObservableCollection<Fund>(fundContext.Funds.Where(f => fundCodes.Contains(f.FONKODU)).ToList());
            //}


            //PortfolioFundManager portfolioFundManager = new(new EfPortfolioFundDal());
            //var fundCodes = portfolioFundManager.GetAllPortfolioFunds().Select(p => p.FONKODU).ToList();

            //ComparisonFundManager comparisonFundManager = new(new EfComparisonFundDal());

            //Funds = new ObservableCollection<Fund>(comparisonFundManager.GetAllComparisonFunds(f => fundCodes.Contains(f.FONKODU)).ToList());


            //PortfolioFundManager portfolioFundManager = new(new EfPortfolioFundDal(), new EfComparisonFundDal());

            _funds = new ObservableCollection<Fund>(_portfolioFundService.GetAllPortfolioFunds());
        }

        //public DelegateCommand<Fund> DeletePortfolioFundCommand =>
        //_deletePortfolioFundCommand ?? (_deletePortfolioFundCommand = new DelegateCommand<Fund>(ExecuteDeletePortfolioFundCommand));
        public DelegateCommand<Fund> DeletePortfolioFundCommand =>
            _deletePortfolioFundCommand ?? (_deletePortfolioFundCommand = new DelegateCommand<Fund>(ExecuteDeletePortfolioFundCommand));

        void ExecuteDeletePortfolioFundCommand(Fund fund)
        {
            Funds.Remove(fund);
        }
    }
}
