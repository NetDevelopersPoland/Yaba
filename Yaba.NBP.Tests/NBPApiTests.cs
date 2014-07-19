using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTests : IUseFixture<NBPApiTestsFixture>
    {        
        private INBPDataSource _NBPDataSource;

        public void SetFixture(NBPApiTestsFixture fixture)
        {
            _NBPDataSource = fixture.GetMockedNBPDataSource();
        }

        public static IEnumerable<object[]> TestData
        {
            get
            {
                return new[]
                {
                    new object[] { Currency.THB, 0.0954M },
                    new object[] { Currency.USD, 3.0652M },
                    new object[] { Currency.AUD, 2.8761M },
                    new object[] { Currency.HKD, 0.3954M },
                    new object[] { Currency.CAD, 2.8502M },
                    new object[] { Currency.NZD, 2.6595M },
                    new object[] { Currency.SGD, 2.4690M },
                    new object[] { Currency.EUR, 4.1479M },
                    new object[] { Currency.HUF, 1.3364M },
                    new object[] { Currency.CHF, 3.4169M },
                    new object[] { Currency.GBP, 5.2439M },
                    new object[] { Currency.UAH, 0.2619M },
                    new object[] { Currency.JPY, 3.0225M },
                    new object[] { Currency.CZK, 0.1512M },
                    new object[] { Currency.DKK, 0.5562M },
                    new object[] { Currency.ISK, 2.6778M },
                    new object[] { Currency.NOK, 0.4956M },
                    new object[] { Currency.SEK, 0.4495M },
                    new object[] { Currency.HRK, 0.5445M },
                    new object[] { Currency.RON, 0.9339M },
                    new object[] { Currency.BGN, 2.1208M },
                    new object[] { Currency.TRY, 1.4412M },
                    new object[] { Currency.LTL, 1.2013M },
                    new object[] { Currency.ILS, 0.8960M },
                    new object[] { Currency.CLP, 0.5425M },
                    new object[] { Currency.PHP, 0.0705M },
                    new object[] { Currency.MXN, 0.2365M },
                    new object[] { Currency.ZAR, 0.2872M },
                    new object[] { Currency.BRL, 1.3569M },
                    new object[] { Currency.MYR, 0.9627M },
                    new object[] { Currency.RUB, 0.0875M },
                    new object[] { Currency.IDR, 2.6195M },
                    new object[] { Currency.INR, 5.0803M },
                    new object[] { Currency.KRW, 0.2977M },
                    new object[] { Currency.CNY, 0.4937M },
                    new object[] { Currency.XDR, 4.7272M }
                };
            }
        }

        [Theory]
        [PropertyData("TestData")]
        public void NBPApi_providedCurrency_shouldReturnActualExchangeRate(Currency providedCurrency, decimal expectedExchangeRateValue)
        {
            // Arrange
            NBPApi sut = new NBPApi(_NBPDataSource);

            // Act
            ExchangeRate exchangeRate = sut.GetActualExchangeRate(providedCurrency);

            // Assert
            Assert.Equal(expectedExchangeRateValue, exchangeRate.Value);
        }
    }
}