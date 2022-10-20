using InvestmentMaster.BL.Abstract;
using InvestmentMaster.BL.Concrete.Managers;
using InvestmentMaster.DataAccess.Abstract;
using InvestmentMaster.DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.BL.DependncyResolvers.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IComparisonFundService>().To<ComparisonFundManager>().InSingletonScope();
            Bind<IComparisonFundDal>().To<EfComparisonFundDal>().InSingletonScope();

            Bind<DbContext>().To<FundContext>().InSingletonScope();

            Bind<IPortfolioFundService>().To<PortfolioFundManager>().InSingletonScope();
            Bind<IPortfolioFundDal>().To<EfPortfolioFundDal>().InSingletonScope();
        }
    }
}
