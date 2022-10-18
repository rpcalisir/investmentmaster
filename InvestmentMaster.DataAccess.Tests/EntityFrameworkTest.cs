using InvestmentMaster.DataAccess.Concrete.EntityFramework;

namespace InvestmentMaster.DataAccess.Tests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_funds()
        {
            EfComparisonFundDal efFundDal = new EfComparisonFundDal();

            var result = efFundDal.GetAll();
            Assert.AreEqual(450, result.Count);
        }

        [TestMethod]    
        public void Get_all_with_parameter_returns_filtered_funds()
        {
            EfComparisonFundDal efFundDal = new EfComparisonFundDal();

            var result = efFundDal.GetAll(f => f.FONTURACIKLAMA.Contains("Hisse"));

            Assert.AreEqual(86, result.Count);

        }
    }
}