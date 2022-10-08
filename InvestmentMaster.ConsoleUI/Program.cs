using InvestmentMaster.DataAccess.API;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentMaster.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Saving Data...");

            List<Fund> funds = ComparisonFundReturns.GetFunds();


            if (funds != null)
            {
                using (FundContext context = new FundContext())
                {
                    context.Database.EnsureCreated();

                    Console.WriteLine("Database is created!");
                    //if (context.Funds.Count() == 0)
                    //{
                    //    context.Funds.AddRange(funds);
                    //    context.SaveChanges();
                    //}

                    //    context.Funds.DeleteFromQuery();
                    //    context.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Funds]");

                    //    #pragma warning disable CS8602 // Dereference of a possibly null reference.
                    //    context.Funds.AddRange(funds);
                    //    #pragma warning restore CS8602 // Dereference of a possibly null reference.
                    //    context.SaveChanges();

                }
            }
            else
            {
                Console.WriteLine("Response is not ok!");
            }


            //ComparisonFundReturns comparisonFundReturns = new ComparisonFundReturns();
            //List<Fund> funds = ComparisonFundReturns.GetFundsSortedByOneMonthDesc();

            //List<Fund> funds = ComparisonFundReturns.GetFundsSortedByAscending(ComparisonFundReturns.GetFunds(), f => f.GETIRI3A);

            List<Fund> fundsFromDb;
            using (FundContext fundContext = new FundContext())
            {
                fundsFromDb = fundContext.Funds.ToList();
            }

            Console.WriteLine(String.Format("{0,-10} | {1,-100} | {2,-30} | {3,-8} | {4,-15} | {5,-15} | {6,-15} | {7,-15} | {8,-15} | {9,-15}", "Fon Kodu", "Fon Adı", "Şemsiye Fon Türü", "1 Ay(%)", "3 Ay(%)", "6 Ay(%)", "Yılbaşı(%)", "1 Yıl(%)", "3 Yıl(%)", "5 Yıl(%)"));
            //foreach (var fund in fundsFromDb.Where(f => f.FONKODU.Equals("AFA")))
            foreach (var fund in fundsFromDb)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-100} | {2,-30} | {3,-8} | {4,-15} | {5,-15} | {6,-15} | {7,-15} | {8,-15} | {9,-15}", fund.FONKODU, fund.FONUNVAN, fund.FONTURACIKLAMA, fund.GETIRI1A, fund.GETIRI3A, fund.GETIRI6A, fund.GETIRIYB, fund.GETIRI1Y, fund.GETIRI3Y, fund.GETIRI5Y));
            }


            //using (FundContext fundContext = new FundContext())
            //{
            //    //var fundsOfTable = fundContext.Funds.ToList();

            //    //fundContext.Funds.RemoveRange(fundsOfTable);
            //    //fundContext.SaveChanges();

            //    var fundsOfTable = fundContext.Funds.ToList();

            //    //Deletes all rows but primary key is increasing after last one.
            //    fundContext.RemoveRange(fundsOfTable);
            //    fundContext.SaveChanges();

            //    //Deletes all existing rows and make it possible that primary key is not increasing after last one.
            //    fundContext.Database.ExecuteSqlRaw("TRUNCATE TABLE [dbo].[Funds]");

            //    fundContext.SaveChanges();

            //    fundContext.Funds.AddRange(funds);

            //    fundContext.SaveChanges();
            //}

            Console.WriteLine("Data is saved.");

            Console.ReadLine();

            using (FundContext fundContext = new FundContext())
            {
                fundContext.Database.EnsureDeleted();
                Console.WriteLine("Database is deleted!");
            }

            Console.ReadLine();
        }
    }
}
