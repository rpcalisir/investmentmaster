using InvestmentMaster.Core.DataAccess.EntityFramework;
using InvestmentMaster.DataAccess.Abstract;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.DataAccess.Concrete.EntityFramework
{
    public class EfFundDal: EfEntityRepositoryBase<Fund, FundContext>, IFundDal
    {
    }
}
