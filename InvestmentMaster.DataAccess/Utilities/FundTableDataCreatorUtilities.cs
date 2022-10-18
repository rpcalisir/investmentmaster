using InvestmentMaster.DataAccess.API;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.Entities.Concrete;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
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
                    if (!context.Database.GetService<IRelationalDatabaseCreator>().Exists())
                    {
                        //TODO LOG
                        context.Database.EnsureCreated();
                    }

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
