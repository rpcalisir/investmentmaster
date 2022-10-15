using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.BL.Abstract
{
    public interface IFundService
    {
        List<Fund> GetAllFunds();
    }
}
