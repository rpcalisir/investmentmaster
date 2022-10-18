using InvestmentMaster.DataAccess.API;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.DataAccess.Utilities
{
    public class FundTableDataCreatorUtilities
    {
        public static bool CreateFundTableData()
        {
            List<Fund> funds = ComparisonFundReturns.GetFunds();

            if (funds != null)
            {
                using (FundContext context = new FundContext())
                {
                    context.Database.EnsureCreated();

                    Console.WriteLine("Database is created!");

                    if (!context.ComparisonFunds.Any())
                    {
                        context.ComparisonFunds.AddRange(funds);
                        context.SaveChanges();
                    }
                }
                return true;
            }
            else
            {
                Console.WriteLine("Response is not ok!");
                return false;
            }
        }
    }
}
