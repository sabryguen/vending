using System.Collections.Generic;
using NUnit.Framework;
using TicketArena.Domain;

namespace TicketArena.Business.Tests
{
    [TestFixture]
    public class ChangeDispenserTests
    {
        [Test]
        public void DispenseChange_ZeroAmount_ExpectNull()
        {
            // Arrange
            IChangeDispenser sut = new ChangeDispenser();

            // Act
            List<Coin> coins = sut.DispenseChange(0);

            // Assert
            Assert.IsNull(coins);
        }

        [Test]
        public void DispenseChange_CheckNickel()
        {
            // Arrange
            IChangeDispenser sut = new ChangeDispenser();

            // Act
            List<Coin> coins = sut.DispenseChange(0.05m);

            // Assert
            Assert.IsNotNull(coins);
            Assert.AreEqual(1, coins.Count);
            Assert.AreEqual("Nickel", coins[0].Name);
        }

        [Test]
        public void DispenseChange_CheckDime()
        {
            // Arrange
            IChangeDispenser sut = new ChangeDispenser();

            // Act
            List<Coin> coins = sut.DispenseChange(0.10m);

            // Assert
            Assert.IsNotNull(coins);
            Assert.AreEqual(1, coins.Count);
            Assert.AreEqual("Dime", coins[0].Name);
        }

        [Test]
        public void DispenseChange_CheckQuarter()
        {
            // Arrange
            IChangeDispenser sut = new ChangeDispenser();

            // Act
            List<Coin> coins = sut.DispenseChange(0.25m);

            // Assert
            Assert.IsNotNull(coins);
            Assert.AreEqual(1, coins.Count);
            Assert.AreEqual("Quarter", coins[0].Name);
        }

        [Test]
        public void DispenseChange_CheckHalfDollar()
        {
            // Arrange
            IChangeDispenser sut = new ChangeDispenser();

            // Act
            List<Coin> coins = sut.DispenseChange(0.50m);

            // Assert
            Assert.IsNotNull(coins);
            Assert.AreEqual(1, coins.Count);
            Assert.AreEqual("Half Dollar", coins[0].Name);
        }

        [Test]
        public void DispenseChange_CheckDollar()
        {
            // Arrange
            IChangeDispenser sut = new ChangeDispenser();

            // Act
            List<Coin> coins = sut.DispenseChange(1.00m);

            // Assert
            Assert.IsNotNull(coins);
            Assert.AreEqual(1, coins.Count);
            Assert.AreEqual("Dollar", coins[0].Name);
        }
    }
}
