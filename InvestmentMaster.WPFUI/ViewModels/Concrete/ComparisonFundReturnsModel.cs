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
        public static ObservableCollection<Fund> Funds { get; }

        static ComparisonFundReturnsModel()
        {
            EfFundDal efFundDal = new EfFundDal();
            Funds = new ObservableCollection<Fund>(efFundDal.GetAll());
        }
    }
}
