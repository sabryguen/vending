using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using TicketArena.Domain;

namespace TicketArena.Business.Tests
{
    [TestFixture]
    public class VendingManagerTests
    {
        [Test]
        public void SelectProduct_CheckProductSet()
        {
            // Arrange
            Mock<ICoinResolver> mockCoinResolver = new Mock<ICoinResolver>();
            Mock<IChangeDispenser> mockChangeDispenser = new Mock<IChangeDispenser>();

            // Act
            VendingManager sut = new VendingManager(mockCoinResolver.Object, mockChangeDispenser.Object);
            sut.SelectProduct(new Product("blah", 123.45m));

            // Assert
            var product = sut.SelectedProduct;

            Assert.AreEqual("blah", product.Name);
            Assert.AreEqual(123.45m, product.Cost);            
        }

        [Test]
        public void AddCoin_NoProductSelected()
        {
            // Arrange
            Mock<ICoinResolver> mockCoinResolver = new Mock<ICoinResolver>();
            Mock<IChangeDispenser> mockChangeDispenser = new Mock<IChangeDispenser>();

            // Act
            VendingManager sut = new VendingManager(mockCoinResolver.Object, mockChangeDispenser.Object);
            sut.DisplayUpdated += Sut_DisplayUpdated;
            sut.AddCoin(2.5m, 30);

            // Assert
            Assert.IsNull(sut.SelectedProduct);
        }

        private void Sut_DisplayUpdated(object sender, EventArgs.DisplayEventArgs e)
        {
            Assert.AreEqual("PLEASE CHOOSE A PRODUCT", e.Message);
        }

        [Test]
        public void AddCoin_UnresolvedCoin()
        {            
            // Arrange
            Mock<ICoinResolver> mockCoinResolver = new Mock<ICoinResolver>();

            decimal testCoinWeight = 12.0m;
            decimal testCointDiameter = 23.45m;

            Coin aCoin = null;
            mockCoinResolver.Setup(x => x.ResolveCoin(testCoinWeight, testCointDiameter)).Returns(aCoin);
            Mock<IChangeDispenser> mockChangeDispenser = new Mock<IChangeDispenser>();

            // Act
            VendingManager sut = new VendingManager(mockCoinResolver.Object, mockChangeDispenser.Object);
            sut.SelectProduct(new Product("a product", 13.56m)); // simulate the buyer placing an unrecognisable coin.
            sut.UnrecognisedCoinReturned += Sut_UnrecognisedCoinReturned;
            sut.AddCoin(testCoinWeight, testCointDiameter);

            // Assert
            Assert.IsNotNull(sut.SelectedProduct);
        }

        private void Sut_UnrecognisedCoinReturned(object sender, EventArgs.UnrecognisedCoinReturnedEventArgs e)
        {
            Assert.AreEqual("Coin not accepted", e.Message);
            Assert.AreEqual(12.0m, e.CoinWeight);
            Assert.AreEqual(23.45m, e.CointDiameter);
        }

        [Test]
        public void AddCoin_CoinResolved_EqualToSumOfProduct_ExpectDispenseButNoChange()
        {
            // Arrange
            Mock<ICoinResolver> mockCoinResolver = new Mock<ICoinResolver>();

            decimal testCoinWeight = 12.0m;
            decimal testCointDiameter = 23.45m;

            Coin aCoin = new Coin("Dollar", testCoinWeight, testCointDiameter, 1.00m);

            mockCoinResolver.Setup(x => x.ResolveCoin(testCoinWeight, testCointDiameter)).Returns(aCoin);
            Mock<IChangeDispenser> mockChangeDispenser = new Mock<IChangeDispenser>();

            // Act
            VendingManager sut = new VendingManager(mockCoinResolver.Object, mockChangeDispenser.Object);
            sut.ProductDispensed += Sut_ProductDispensed;
            sut.SelectProduct(new Product("Rola Cola", 1.00m));

            sut.AddCoin(testCoinWeight, testCointDiameter);

            // Coins should be clear since we dispensed the product ready for the next transaction.
            Assert.AreEqual(0, sut.Coins.Count);

            mockChangeDispenser.Verify(x => x.DispenseChange(0));
        }


        [Test]
        public void AddCoin_CoinResolved_EqualToSumOfProduct_ExpectDispenseWithChange()
        {
            // Arrange
            Mock<ICoinResolver> mockCoinResolver = new Mock<ICoinResolver>();

            decimal testCoinWeight = 12.0m;
            decimal testCointDiameter = 23.45m;

            Coin aCoin = new Coin("2 Dollar", testCoinWeight, testCointDiameter, 2.00m);

            mockCoinResolver.Setup(x => x.ResolveCoin(testCoinWeight, testCointDiameter)).Returns(aCoin);
            Mock<IChangeDispenser> mockChangeDispenser = new Mock<IChangeDispenser>();

            List<Coin> changeCoins = new List<Coin>();
            changeCoins.Add(new Coin("Dollar", CoinConstants.DollarWeight, CoinConstants.DollarDiameter, 1.00m));

            mockChangeDispenser.Setup(x => x.DispenseChange(1.00m)).Returns(changeCoins);

            // Act
            VendingManager sut = new VendingManager(mockCoinResolver.Object, mockChangeDispenser.Object);
            sut.ProductDispensed += Sut_ProductDispensed;
            sut.CoinReturned += Sut_CoinReturned;
            sut.SelectProduct(new Product("Rola Cola", 1.00m));

            sut.AddCoin(testCoinWeight, testCointDiameter);

            // Coins should be clear since we dispensed the product ready for the next transaction.
            Assert.AreEqual(0, sut.Coins.Count);

            mockChangeDispenser.Verify(x => x.DispenseChange(1.00m));
        }

        private void Sut_CoinReturned(object sender, EventArgs.CoinReturnedEventArgs e)
        {
            Assert.AreEqual("Dollar", e.ReturnedCoin.Name);
        }

        private void Sut_ProductDispensed(object sender, EventArgs.ProductDispensedEventArgs e)
        {
            Assert.AreEqual("Rola Cola", e.DispensedProduct.Name);
            Assert.AreEqual(1.00m, e.DispensedProduct.Cost);
        }

        [Test]
        public void CancelOrder_CheckEventsFiredAndCoinsCleared()
        {
            // Arrange
            Mock<ICoinResolver> mockCoinResolver = new Mock<ICoinResolver>();

            decimal testCoinWeight = 12.0m;
            decimal testCointDiameter = 23.45m;

            // Make sure that you stay inside the cost of the product because we 
            // don't want to trigger dispense and coin clear.

            // simulate the buyer placing an unrecognisable coin.
            Coin aCoin = new Coin("Test coin", testCoinWeight, testCointDiameter, 0.05m);
            
            mockCoinResolver.Setup(x => x.ResolveCoin(testCoinWeight, testCointDiameter)).Returns(aCoin);
            Mock<IChangeDispenser> mockChangeDispenser = new Mock<IChangeDispenser>();

            // Act
            VendingManager sut = new VendingManager(mockCoinResolver.Object, mockChangeDispenser.Object);            
            sut.SelectProduct(new Product("a product", 13.56m)); 

            // Assert
            sut.AddCoin(testCoinWeight, testCointDiameter);
            Assert.AreEqual(1, sut.Coins.Count);

            sut.AddCoin(testCoinWeight, testCointDiameter);
            Assert.AreEqual(2, sut.Coins.Count);

            sut.AmountUpdated += Sut_AmountUpdated;
            sut.DisplayUpdated += Sut_DisplayUpdated1;

            sut.CancelOrder();
            Assert.AreEqual(0, sut.Coins.Count);

            Assert.IsNotNull(sut.SelectedProduct);
        }

        private void Sut_AmountUpdated(object sender, EventArgs.AmountEventArgs e)
        {
            Assert.AreEqual(0.00m, e.Amount);
        }

        private void Sut_DisplayUpdated1(object sender, EventArgs.DisplayEventArgs e)
        {
            Assert.AreEqual("INSERT COIN", e.Message);
        }
    }
}
