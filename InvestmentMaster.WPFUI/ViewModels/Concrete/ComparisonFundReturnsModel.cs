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
        //public static ObservableCollection<Fund> Funds { get; }

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
            //Funds = new ObservableCollection<Fund>(fundManager.GetAllComparisonFunds());

            //_comparisonFundService = InstanceFactory.GetInstance<IComparisonFundService>();
        }
    }
}
