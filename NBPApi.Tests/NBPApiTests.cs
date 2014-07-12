using Xunit;

namespace DotNetDevelopersPL.Yaba.Tests
{
    public class NBPApiTests
    {
        [Fact]
        public void GetActualTHBValueTest()
        {
            // Arrange
            Currency currency = Currency.THB;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.THB, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualUSDValueTest()
        {
            // Arrange
            Currency currency = Currency.USD;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.USD, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualAUDValueTest()
        {
            // Arrange
            Currency currency = Currency.AUD;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.AUD, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualHKDValueTest()
        {
            // Arrange
            Currency currency = Currency.HKD;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.HKD, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualCADValueTest()
        {
            // Arrange
            Currency currency = Currency.CAD;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.CAD, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualNZDValueTest()
        {
            // Arrange
            Currency currency = Currency.NZD;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.NZD, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualSGDValueTest()
        {
            // Arrange
            Currency currency = Currency.SGD;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.SGD, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualEURValueTest()
        {
            // Arrange
            Currency currency = Currency.EUR;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.EUR, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualHUFValueTest()
        {
            // Arrange
            Currency currency = Currency.HUF;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.HUF, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualCHFValueTest()
        {
            // Arrange
            Currency currency = Currency.CHF;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.CHF, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualGBPValueTest()
        {
            // Arrange
            Currency currency = Currency.GBP;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.GBP, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualUAHValueTest()
        {
            // Arrange
            Currency currency = Currency.UAH;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.UAH, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualJPYValueTest()
        {
            // Arrange
            Currency currency = Currency.JPY;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.JPY, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualCZKValueTest()
        {
            // Arrange
            Currency currency = Currency.CZK;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.CZK, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualDKKValueTest()
        {
            // Arrange
            Currency currency = Currency.DKK;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.DKK, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualISKValueTest()
        {
            // Arrange
            Currency currency = Currency.ISK;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.ISK, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualNOKValueTest()
        {
            // Arrange
            Currency currency = Currency.NOK;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.NOK, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualSEKValueTest()
        {
            // Arrange
            Currency currency = Currency.SEK;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.SEK, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualHRKValueTest()
        {
            // Arrange
            Currency currency = Currency.HRK;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.HRK, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualRONValueTest()
        {
            // Arrange
            Currency currency = Currency.RON;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.RON, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualBGNValueTest()
        {
            // Arrange
            Currency currency = Currency.BGN;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.BGN, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualTRYValueTest()
        {
            // Arrange
            Currency currency = Currency.TRY;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.TRY, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualLTLValueTest()
        {
            // Arrange
            Currency currency = Currency.LTL;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.LTL, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualILSValueTest()
        {
            // Arrange
            Currency currency = Currency.ILS;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.ILS, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualCLPValueTest()
        {
            // Arrange
            Currency currency = Currency.CLP;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.CLP, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualPHPValueTest()
        {
            // Arrange
            Currency currency = Currency.PHP;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.PHP, money.Currency);
            Assert.True(money.Value > 0M);
        }
        
        [Fact]
        public void GetActualMXNValueTest()
        {
            // Arrange
            Currency currency = Currency.MXN;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.MXN, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualZARValueTest()
        {
            // Arrange
            Currency currency = Currency.ZAR;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.ZAR, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualBRLValueTest()
        {
            // Arrange
            Currency currency = Currency.BRL;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.BRL, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualMYRValueTest()
        {
            // Arrange
            Currency currency = Currency.MYR;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.MYR, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualRUBValueTest()
        {
            // Arrange
            Currency currency = Currency.RUB;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.RUB, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualIDRValueTest()
        {
            // Arrange
            Currency currency = Currency.IDR;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.IDR, money.Currency);
            Assert.True(money.Value > 0M);
        }
        
        [Fact]
        public void GetActualINRValueTest()
        {
            // Arrange
            Currency currency = Currency.INR;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.INR, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualKRWValueTest()
        {
            // Arrange
            Currency currency = Currency.KRW;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.KRW, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualCNYValueTest()
        {
            // Arrange
            Currency currency = Currency.CNY;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.CNY, money.Currency);
            Assert.True(money.Value > 0M);
        }

        [Fact]
        public void GetActualXDRValueTest()
        {
            // Arrange
            Currency currency = Currency.XDR;
            NBPApi nbpApi = new NBPApi();

            // Act
            Money money = nbpApi.GetActualExchangeRate(currency);

            // Assert
            Assert.Equal(Currency.XDR, money.Currency);
            Assert.True(money.Value > 0M);
        }
    }
}
