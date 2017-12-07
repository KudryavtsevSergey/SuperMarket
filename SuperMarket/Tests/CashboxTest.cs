using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns(It.IsAny<string>());
            moqProduct.SetupGet(s => s.Price).Returns(It.IsAny<int>());
            IProduct product = moqProduct.Object;
            cashbox.Scan(product);

            int actual = cashbox.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scan_RemoveProduct_ContainZeroProduct()
        {
            int expected = 0;
            ICashbox cashbox = new Cashbox();
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns(It.IsAny<string>());
            moqProduct.SetupGet(s => s.Price).Returns(It.IsAny<int>());
            IProduct product = moqProduct.Object;
            cashbox.Scan(product);
            cashbox.Remove(product);

            int actual = cashbox.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Scan_RemoveProduct_ContainOneProduct()
        {
            int expected = 1;
            ICashbox cashbox = new Cashbox();
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns(It.IsAny<string>());
            moqProduct.SetupGet(s => s.Price).Returns(It.IsAny<int>());
            IProduct product = moqProduct.Object;
            cashbox.Scan(product);
            cashbox.Scan(product);
            cashbox.Remove(product);

            int actual = cashbox.Count();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_Add7Sweet2_34Price_Return16_38()
        {
            double expected = 16.38;
            ICashbox cashbox = new Cashbox();
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("sweet");
            moqProduct.SetupGet(s => s.Price).Returns(2.34);
            IProduct product = moqProduct.Object;
            for (int i = 0; i < 7; i++)
            {
                cashbox.Scan(product);
            }
            double actual = cashbox.Check();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_AddSevenSweetWithPrice234_SixProductDiscountWithPrice123_Return603()
        {
            double expected = 603;
            ICashbox cashbox = new Cashbox();

            var moqDiscount = new Mock<IDiscount>();
            moqDiscount.SetupGet(s => s.Count).Returns(2);
            moqDiscount.SetupGet(s => s.Price).Returns(123);
            IDiscount discount = moqDiscount.Object;

            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("sweet");
            moqProduct.SetupGet(s => s.Price).Returns(234);
            moqProduct.SetupGet(s => s.Discount).Returns(discount);

            moqProduct.Setup(s => s.hasDiscount()).Returns(true);

            IProduct product = moqProduct.Object;
            for (int i = 0; i < 7; i++)
            {
                cashbox.Scan(product);
            }
            double actual = cashbox.Check();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_MethodCountAndPriceDiscountWasCalled()
        {
            ICashbox cashbox = new Cashbox();

            var moqDiscount = new Mock<IDiscount>();
            moqDiscount.SetupGet(s => s.Count).Returns(2);
            moqDiscount.SetupGet(s => s.Price).Returns(123);
            IDiscount discount = moqDiscount.Object;

            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("sweet");
            moqProduct.SetupGet(s => s.Price).Returns(234);
            moqProduct.SetupGet(s => s.Discount).Returns(discount);

            moqProduct.Setup(s => s.hasDiscount()).Returns(true);

            IProduct product = moqProduct.Object;
            for (int i = 0; i < 7; i++)
            {
                cashbox.Scan(product);
            }
            cashbox.Check();
            moqDiscount.VerifyAll();
        }

        [TestMethod]
        public void Check_HasDiscountPriceAndCalled()
        {
            ICashbox cashbox = new Cashbox();

            var moqDiscount = new Mock<IDiscount>();
            moqDiscount.SetupGet(s => s.Count).Returns(2);
            moqDiscount.SetupGet(s => s.Price).Returns(123);
            IDiscount discount = moqDiscount.Object;

            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Price).Returns(234);
            moqProduct.SetupGet(s => s.Discount).Returns(discount);

            moqProduct.Setup(s => s.hasDiscount()).Returns(true);

            IProduct product = moqProduct.Object;
            for (int i = 0; i < 7; i++)
            {
                cashbox.Scan(product);
            }
            double actual = cashbox.Check();
            moqProduct.VerifyAll();
        }

        [TestMethod]
        public void Check_Add3Sweet3PriceAnd4Banana4Price3Discount1Price_Return16_38()
        {
            double expected = 14;
            ICashbox cashbox = new Cashbox();
            var moqProductSweet = new Mock<IProduct>();
            moqProductSweet.SetupGet(s => s.Name).Returns("sweet");
            moqProductSweet.SetupGet(s => s.Price).Returns(3);
            IProduct productSweet = moqProductSweet.Object;

            var moqProductBanana = new Mock<IProduct>();
            moqProductBanana.SetupGet(s => s.Name).Returns("banana");
            moqProductBanana.SetupGet(s => s.Price).Returns(4);
            moqProductBanana.Setup(s => s.hasDiscount()).Returns(true);

            var moqDiscountBanana = new Mock<IDiscount>();
            moqDiscountBanana.SetupGet(s => s.Count).Returns(3);
            moqDiscountBanana.SetupGet(s => s.Price).Returns(1);
            IDiscount discountBanana = moqDiscountBanana.Object;

            moqProductBanana.SetupGet(s => s.Discount).Returns(discountBanana);

            IProduct productBanana = moqProductBanana.Object;

            for (int i = 0; i < 3; i++)
            {
                cashbox.Scan(productSweet);
            }

            for (int i = 0; i < 4; i++)
            {
                cashbox.Scan(productBanana);
            }

            double actual = cashbox.Check();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_Add15Sweet3Price4Discount2PriceAnd4Banana4Price3Discount1Price_Return16_38()
        {
            double expected = 20;
            ICashbox cashbox = new Cashbox();
            var moqProductSweet = new Mock<IProduct>();
            moqProductSweet.SetupGet(s => s.Name).Returns("sweet");
            moqProductSweet.SetupGet(s => s.Price).Returns(3);
            moqProductSweet.Setup(s => s.hasDiscount()).Returns(true);

            var moqDiscountSweet = new Mock<IDiscount>();
            moqDiscountSweet.SetupGet(s => s.Count).Returns(4);
            moqDiscountSweet.SetupGet(s => s.Price).Returns(2);
            IDiscount discountSweet = moqDiscountSweet.Object;

            moqProductSweet.SetupGet(s => s.Discount).Returns(discountSweet);

            IProduct productSweet = moqProductSweet.Object;

            var moqProductBanana = new Mock<IProduct>();
            moqProductBanana.SetupGet(s => s.Name).Returns("banana");
            moqProductBanana.SetupGet(s => s.Price).Returns(4);
            moqProductBanana.Setup(s => s.hasDiscount()).Returns(true);

            var moqDiscountBanana = new Mock<IDiscount>();
            moqDiscountBanana.SetupGet(s => s.Count).Returns(3);
            moqDiscountBanana.SetupGet(s => s.Price).Returns(1);
            IDiscount discountBanana = moqDiscountBanana.Object;

            moqProductBanana.SetupGet(s => s.Discount).Returns(discountBanana);

            IProduct productBanana = moqProductBanana.Object;

            for (int i = 0; i < 15; i++)
            {
                cashbox.Scan(productSweet);
            }

            for (int i = 0; i < 4; i++)
            {
                cashbox.Scan(productBanana);
            }

            double actual = cashbox.Check();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Check_Add3Sweet3PriceAnd4Banana4Price3Discount1Price_Return16_38_InRandom()
        {
            double expected = 14;
            ICashbox cashbox = new Cashbox();
            var moqProductSweet = new Mock<IProduct>();
            moqProductSweet.SetupGet(s => s.Name).Returns("sweet");
            moqProductSweet.SetupGet(s => s.Price).Returns(3);
            IProduct productSweet = moqProductSweet.Object;

            var moqProductBanana = new Mock<IProduct>();
            moqProductBanana.SetupGet(s => s.Name).Returns("banana");
            moqProductBanana.SetupGet(s => s.Price).Returns(4);
            moqProductBanana.Setup(s => s.hasDiscount()).Returns(true);

            var moqDiscountBanana = new Mock<IDiscount>();
            moqDiscountBanana.SetupGet(s => s.Count).Returns(3);
            moqDiscountBanana.SetupGet(s => s.Price).Returns(1);
            IDiscount discountBanana = moqDiscountBanana.Object;

            moqProductBanana.SetupGet(s => s.Discount).Returns(discountBanana);

            IProduct productBanana = moqProductBanana.Object;

            cashbox.Scan(productSweet);
            cashbox.Scan(productBanana);
            cashbox.Scan(productSweet);
            cashbox.Scan(productBanana);
            cashbox.Scan(productBanana);
            cashbox.Scan(productSweet);
            cashbox.Scan(productBanana);

            double actual = cashbox.Check();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void PrintCheck_CountTimesCall()
        {
            ICashbox cashbox = new Cashbox();

            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("sweet");
            moqProduct.SetupGet(s => s.Price).Returns(234);

            moqProduct.Setup(s => s.hasDiscount()).Returns(false);

            IProduct product = moqProduct.Object;
            for (int i = 0; i < 7; i++)
            {
                cashbox.Scan(product);
            }
            cashbox.PrintCheck();
            moqProduct.Verify(s => s.Price, Times.Exactly(1));
            moqProduct.Verify(s => s.Name, Times.Exactly(1));
        }

        [TestMethod]
        public void IsContain_AddProduct_Contain()
        {
            bool expected = true;
            ICashbox cashbox = new Cashbox();
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("test");
            moqProduct.SetupGet(s => s.Price).Returns(1.4);
            IProduct product = moqProduct.Object;
            cashbox.Scan(product);

            bool actual = cashbox.IsContain("test");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsContain_AddProduct_NotContain()
        {
            bool expected = false;
            ICashbox cashbox = new Cashbox();
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("test");
            moqProduct.SetupGet(s => s.Price).Returns(1.4);
            IProduct product = moqProduct.Object;
            cashbox.Scan(product);

            bool actual = cashbox.IsContain("name");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOneProduct_Add5Product_Return5()
        {
            int expected = 5;
            ICashbox cashbox = new Cashbox();
            var moqProductSweet = new Mock<IProduct>();
            moqProductSweet.SetupGet(s => s.Name).Returns("Sweet");
            moqProductSweet.SetupGet(s => s.Price).Returns(It.IsAny<int>());
            IProduct productSweet = moqProductSweet.Object;
            var moqProductBanana = new Mock<IProduct>();
            moqProductBanana.SetupGet(s => s.Name).Returns(It.IsAny<string>());
            moqProductBanana.SetupGet(s => s.Price).Returns(It.IsAny<int>());
            IProduct productBanana = moqProductBanana.Object;
            for (int i = 0; i < 5; i++)
            {
                cashbox.Scan(productSweet);
            }
            for (int i = 0; i < 5; i++)
            {
                cashbox.Scan(productBanana);
            }

            int actual = cashbox.CountOneProduct("Sweet");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CountOneProduct_Add5Product_Return0()
        {
            int expected = 0;
            ICashbox cashbox = new Cashbox();
            var moqProduct = new Mock<IProduct>();
            moqProduct.SetupGet(s => s.Name).Returns("Banana");
            moqProduct.SetupGet(s => s.Price).Returns(It.IsAny<int>());
            IProduct product = moqProduct.Object;
            for (int i = 0; i < 5; i++)
            {
                cashbox.Scan(product);
            }

            int actual = cashbox.CountOneProduct("Sweet");
            Assert.AreEqual(expected, actual);
        }
    }
}
