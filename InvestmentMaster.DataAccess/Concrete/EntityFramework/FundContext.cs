using InvestmentMaster.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.DataAccess.Concrete.EntityFramework
{
    public class FundContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;Database=Funds;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;initial catalog=FonSepetiDb;integrated security=true");


            optionsBuilder.UseSqlServer(@"server=(localdb)\MSSQLLocalDB;initial catalog=InvestmentMasterDb;integrated security=true;MultipleActiveResultSets=True");

            //z.EntityFramework.Extensions.EFCore
            //var connectionString = ConfigurationManager.ConnectionStrings[this.GetType().Name].ConnectionString;

            //Microsoft.EntityFrameworkCore.SqlServer
            //optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Fund>? ComparisonFunds { get; set; }

        public DbSet<SelectedFund> PortfolioFunds { get; set; }
    }
}
