using InvestmentMaster.DataAccess.Concrete.EntityFramework;

namespace InvestmentMaster.DataAccess.Tests
{
    [TestClass]
    public class EntityFrameworkTest
    {
        [TestMethod]
        public void Get_all_returns_all_funds()
        {
            EfFundDal efFundDal = new EfFundDal();

            var result = efFundDal.GetAll();
            Assert.AreEqual(450, result.Count);
        }
    }
}