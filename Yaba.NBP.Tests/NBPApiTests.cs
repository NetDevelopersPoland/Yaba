using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTests
    {
        public static IEnumerable<object[]> FakeData
        {
            get
            {
                return new[]
                {
                    new object[] { Currency.THB, 0.0947M },
                    new object[] { Currency.USD, 3.0454M },
                    new object[] { Currency.AUD, 2.8538M },
                    new object[] { Currency.HKD, 0.3930M },
                    new object[] { Currency.CAD, 2.8371M },
                    new object[] { Currency.NZD, 2.6785M },
                    new object[] { Currency.SGD, 2.4513M },
                    new object[] { Currency.EUR, 4.1433M },
                    new object[] { Currency.HUF, 1.3390M },
                    new object[] { Currency.CHF, 3.4124M },
                    new object[] { Currency.GBP, 5.2196M },
                    new object[] { Currency.UAH, 0.2600M },
                    new object[] { Currency.JPY, 2.9989M },
                    new object[] { Currency.CZK, 0.1510M },
                    new object[] { Currency.DKK, 0.5556M },
                    new object[] { Currency.ISK, 2.6619M },
                    new object[] { Currency.NOK, 0.4920M },
                    new object[] { Currency.SEK, 0.4485M },
                    new object[] { Currency.HRK, 0.5443M },
                    new object[] { Currency.RON, 0.9380M },
                    new object[] { Currency.BGN, 2.1185M },
                    new object[] { Currency.TRY, 1.4358M },
                    new object[] { Currency.LTL, 1.2000M },
                    new object[] { Currency.ILS, 0.8944M },
                    new object[] { Currency.CLP, 0.5501M },
                    new object[] { Currency.PHP, 0.0698M },
                    new object[] { Currency.MXN, 0.2348M },
                    new object[] { Currency.ZAR, 0.2843M },
                    new object[] { Currency.BRL, 1.3778M },
                    new object[] { Currency.MYR, 0.9577M },
                    new object[] { Currency.RUB, 0.0887M },
                    new object[] { Currency.IDR, 2.6075M },
                    new object[] { Currency.INR, 5.0647M },
                    new object[] { Currency.KRW, 0.2965M },
                    new object[] { Currency.CNY, 0.4906M },
                    new object[] { Currency.XDR, 4.6991M }
                };
            }
        }

        [Theory]
        [PropertyData("FakeData")]        
        public void NBPApi_providedCurrency_shouldReturnActualExchangeRate(Currency providedCurrency, decimal expectedExchangeRate)
        {
            // Arrange
            NBPApi sut = new NBPApi();

            // Act
            Money money = sut.GetActualExchangeRate(providedCurrency);

            // Assert
            Assert.Equal(expectedExchangeRate, money.ExchangeRate);
        }
    }
}