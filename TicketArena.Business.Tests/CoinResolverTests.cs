using NUnit.Framework;
using TicketArena.Domain;

namespace TicketArena.Business.Tests
{
    [TestFixture]
    public class CoinResolverTests
    {
        [Test]
        public void ResolveCoin_NegativeValues_ExpectNull()
        {
            // Act
            ICoinResolver sut = new CoinResolver();
            Coin aCoin = sut.ResolveCoin(-1, -1);

            // Assert
            Assert.IsNull(aCoin);
        }

        [Test]
        public void ResolveCoin_NotRecognised()
        {
            // Act
            ICoinResolver sut = new CoinResolver();
            Coin aCoin = sut.ResolveCoin(23, 67);

            // Assert
            Assert.IsNull(aCoin);
        }

        [Test]
        public void ResolveCoin_Nickel()
        {
            ICoinResolver sut = new CoinResolver();
            
            // Act
            Coin aCoin = sut.ResolveCoin(CoinConstants.NickelWeight, CoinConstants.NickelDiameter);

            // Assert
            Assert.IsNotNull(aCoin);
            Assert.AreEqual("Nickel", aCoin.Name);
            Assert.AreEqual(CoinConstants.NickelDiameter, aCoin.DiameterMm);
            Assert.AreEqual(CoinConstants.NickelWeight, aCoin.MassGrams);
            Assert.AreEqual(0.05m, aCoin.MonetaryValue);
        }

        [Test]
        public void ResolveCoin_Dime()
        {
            ICoinResolver sut = new CoinResolver();

            // Act
            Coin aCoin = sut.ResolveCoin(CoinConstants.DimeWeight, CoinConstants.DimeDiameter);

            // Assert
            Assert.IsNotNull(aCoin);
            Assert.AreEqual("Dime", aCoin.Name);
            Assert.AreEqual(CoinConstants.DimeDiameter, aCoin.DiameterMm);
            Assert.AreEqual(CoinConstants.DimeWeight, aCoin.MassGrams);
            Assert.AreEqual(0.10m, aCoin.MonetaryValue);
        }

        [Test]
        public void ResolveCoin_Quarter()
        {
            ICoinResolver sut = new CoinResolver();

            // Act
            Coin aCoin = sut.ResolveCoin(CoinConstants.QuarterWeight, CoinConstants.QuarterDiameter);

            // Assert
            Assert.IsNotNull(aCoin);
            Assert.AreEqual("Quarter", aCoin.Name);
            Assert.AreEqual(CoinConstants.QuarterDiameter, aCoin.DiameterMm);
            Assert.AreEqual(CoinConstants.QuarterWeight, aCoin.MassGrams);
            Assert.AreEqual(0.25m, aCoin.MonetaryValue);
        }

        [Test]
        public void ResolveCoin_HalfDollar()
        {
            ICoinResolver sut = new CoinResolver();

            // Act
            Coin aCoin = sut.ResolveCoin(CoinConstants.HalfDollarWeight, CoinConstants.HalfDollarDiameter);

            // Assert
            Assert.IsNotNull(aCoin);
            Assert.AreEqual("Half Dollar", aCoin.Name);
            Assert.AreEqual(CoinConstants.HalfDollarDiameter, aCoin.DiameterMm);
            Assert.AreEqual(CoinConstants.HalfDollarWeight, aCoin.MassGrams);
            Assert.AreEqual(0.50m, aCoin.MonetaryValue);
        }

        [Test]
        public void ResolveCoin_Dollar()
        {
            ICoinResolver sut = new CoinResolver();

            // Act
            Coin aCoin = sut.ResolveCoin(CoinConstants.DollarWeight, CoinConstants.DollarDiameter);

            // Assert
            Assert.IsNotNull(aCoin);
            Assert.AreEqual("Dollar", aCoin.Name);
            Assert.AreEqual(CoinConstants.DollarDiameter, aCoin.DiameterMm);
            Assert.AreEqual(CoinConstants.DollarWeight, aCoin.MassGrams);
            Assert.AreEqual(1.00m, aCoin.MonetaryValue);
        }
    }
}
