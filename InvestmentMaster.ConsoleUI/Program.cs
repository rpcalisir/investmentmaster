using InvestmentMaster.DataAccess.API;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using InvestmentMaster.DataAccess.Utilities;
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

            bool isTableFilled = FundTableDataCreatorUtilities.CreateFundTableData();

            List<Fund> fundsFromDb = new List<Fund>();
            if (isTableFilled)
            {
                EfFundDal efFundDal = new EfFundDal();
                fundsFromDb = efFundDal.GetAll();
            }

            Console.WriteLine(String.Format("{0,-10} | {1,-100} | {2,-30} | {3,-8} | {4,-15} | {5,-15} | {6,-15} | {7,-15} | {8,-15} | {9,-15}", "Fon Kodu", "Fon Adı", "Şemsiye Fon Türü", "1 Ay(%)", "3 Ay(%)", "6 Ay(%)", "Yılbaşı(%)", "1 Yıl(%)", "3 Yıl(%)", "5 Yıl(%)"));
            //foreach (var fund in fundsFromDb.Where(f => f.FONKODU.Equals("AFA")))
            foreach (var fund in fundsFromDb)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-100} | {2,-30} | {3,-8} | {4,-15} | {5,-15} | {6,-15} | {7,-15} | {8,-15} | {9,-15}", fund.FONKODU, fund.FONUNVAN, fund.FONTURACIKLAMA, fund.GETIRI1A, fund.GETIRI3A, fund.GETIRI6A, fund.GETIRIYB, fund.GETIRI1Y, fund.GETIRI3Y, fund.GETIRI5Y));
            }

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
