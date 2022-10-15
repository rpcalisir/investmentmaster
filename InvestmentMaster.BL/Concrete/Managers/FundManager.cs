using InvestmentMaster.BL.Abstract;
using InvestmentMaster.DataAccess.Abstract;
using InvestmentMaster.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentMaster.BL.Concrete.Managers
{
    public class FundManager : IFundService
    {
        IFundDal _fundDal;

        public FundManager(IFundDal fundDal)
        {
            _fundDal = fundDal;
        }

        public List<Fund> GetAllFunds()
        {
            return _fundDal.GetAll();
        }
    }
}
