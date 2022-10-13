using InvestmentMaster.DataAccess.API;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
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
            List<Fund> funds = ComparisonFundReturns.GetFunds();

            if (funds != null)
            {
                using (FundContext context = new FundContext())
                {
                    context.Database.EnsureCreated();

                    if (context.Funds.Count() == 0)
                    {
                        context.Funds.AddRange(funds);
                        context.SaveChanges();
                    }

                    Funds = new ObservableCollection<Fund>(context.Funds.ToList());
                }
            }
        }
    }
}
