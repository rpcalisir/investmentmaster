using InvestmentMaster.Core.DataAccess;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.DataAccess.Abstract
{
    public interface IComparisonFundDal: IEntityRepository<Fund>
    {
    }
}
