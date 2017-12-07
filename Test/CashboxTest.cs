using Microsoft.VisualStudio.TestTools.UnitTesting;
using SuperMarket;

namespace Test
{
    [TestClass]
    public class CashboxTest
    {
        [TestMethod]
        public void Scan_AddProduct_ContainOneProduct()
        {
            int expected = 1;
            ICashbox cashbox = new Cashbox();
        }
    }
}
