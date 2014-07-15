using Xunit;
using Xunit.Extensions;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTests
    {
        [Theory]
        [InlineData(Currency.AUD, Currency.AUD, 1f)]
        [InlineData(Currency.BGN, Currency.BGN, 1f)]
        [InlineData(Currency.BRL, Currency.BRL, 1f)]
        [InlineData(Currency.CAD, Currency.CAD, 1f)]
        [InlineData(Currency.CHF, Currency.CHF, 1f)]
        [InlineData(Currency.CLP, Currency.CLP, 1f)]
        [InlineData(Currency.CNY, Currency.CNY, 1f)]
        [InlineData(Currency.CZK, Currency.CZK, 1f)]
        [InlineData(Currency.DKK, Currency.DKK, 1f)]
        [InlineData(Currency.EUR, Currency.EUR, 1f)]
        [InlineData(Currency.GBP, Currency.GBP, 1f)]
        [InlineData(Currency.HKD, Currency.HKD, 1f)]
        [InlineData(Currency.HRK, Currency.HRK, 1f)]
        [InlineData(Currency.HUF, Currency.HUF, 1f)]
        [InlineData(Currency.IDR, Currency.IDR, 1f)]
        [InlineData(Currency.ILS, Currency.ILS, 1f)]
        [InlineData(Currency.INR, Currency.INR, 1f)]
        [InlineData(Currency.ISK, Currency.ISK, 1f)]
        [InlineData(Currency.JPY, Currency.JPY, 1f)]
        [InlineData(Currency.KRW, Currency.KRW, 1f)]
        [InlineData(Currency.LTL, Currency.LTL, 1f)]
        [InlineData(Currency.MXN, Currency.MXN, 1f)]
        [InlineData(Currency.MYR, Currency.MYR, 1f)]
        [InlineData(Currency.NOK, Currency.NOK, 1f)]
        [InlineData(Currency.NZD, Currency.NZD, 1f)]
        [InlineData(Currency.PHP, Currency.PHP, 1f)]
        [InlineData(Currency.RON, Currency.RON, 1f)]
        [InlineData(Currency.RUB, Currency.RUB, 1f)]
        [InlineData(Currency.SEK, Currency.SEK, 1f)]
        [InlineData(Currency.SGD, Currency.SGD, 1f)]
        [InlineData(Currency.THB, Currency.THB, 1f)]
        [InlineData(Currency.TRY, Currency.TRY, 1f)]
        [InlineData(Currency.UAH, Currency.UAH, 1f)]
        [InlineData(Currency.USD, Currency.USD, 1f)]
        [InlineData(Currency.XDR, Currency.XDR, 1f)]
        [InlineData(Currency.ZAR, Currency.ZAR, 1f)]
        public void NBPApi_providedCurrency_shouldReturnActualExchangeRate(Currency providedCurrency, Currency expectedCurrency, double expectedRate)
        {
            // Arrange
            NBPApi sut = new NBPApi();

            // Act
            Money money = sut.GetActualExchangeRate(providedCurrency);

            // Assert
            Assert.Equal(expectedCurrency, money.Currency);
            Assert.Equal((decimal)expectedRate, money.Value);
        }
    }
}