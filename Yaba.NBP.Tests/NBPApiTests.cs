using NetDevelopersPoland.Yaba.NBP.Tests.Fixtures;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTests : IUseFixture<NBPApiTestsFixture>, IDisposable
    {
        private INBPDataSource _mockedNbpDataSource;

        public void SetFixture(NBPApiTestsFixture fixture)
        {
            _mockedNbpDataSource = fixture.GetMockedNBPDataSource();
        }

        #region Test data

        public static IEnumerable<object[]> ActualExchangeRatesTestData
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

        public static IEnumerable<object[]> ActualBuySellRatesTestData
        {
            get
            {
                return new[] 
                { 
                    new object[] { Currency.DKK, 0.5485M, 0.5595M },
                    new object[] { Currency.SEK, 0.4443M, 0.4533M },
                    new object[] { Currency.NOK, 0.4909M, 0.5009M },
                    new object[] { Currency.CZK, 0.1490M, 0.1520M },
                    new object[] { Currency.JPY, 2.9941M, 3.0545M },
                    new object[] { Currency.GBP, 5.1749M, 5.2795M },
                    new object[] { Currency.CHF, 3.3664M, 3.4344M },
                    new object[] { Currency.HUF, 1.3319M, 1.3589M },
                    new object[] { Currency.EUR, 4.0900M, 4.1726M },
                    new object[] { Currency.CAD, 2.8286M, 2.8858M },
                    new object[] { Currency.XDR, 4.6731M, 4.7675M },
                    new object[] { Currency.USD, 3.0367M, 3.0981M },
                    new object[] { Currency.AUD, 2.8686M, 2.9266M }
                };
            }
        }

        public static IEnumerable<object[]> ActualBaseRatesTestData
        {
            get
            {
                return new[]
                {
                    new object[] { Rate.Reference,  2.5M,  new DateTime(2013, 7, 4) },
                    new object[] { Rate.Lombard,    4.0M,  new DateTime(2013, 7, 4) },
                    new object[] { Rate.Deposit,    1.0M,  new DateTime(2013, 7, 4) },
                    new object[] { Rate.Rediscount, 2.75M, new DateTime(2013, 7, 4) }
                };
            }
        }

        public static IEnumerable<object[]> ArchivalExchangeRatesTestData
        {
            get
            {
                return new[]
                {
                    new object[] { Currency.THB, Table.A, new DateTime(2014, 1, 23), 0.0930M },
                    new object[] { Currency.USD, Table.A, new DateTime(2014, 1, 23), 3.0559M },
                    new object[] { Currency.AUD, Table.A, new DateTime(2014, 1, 23), 2.6909M },
                    new object[] { Currency.HKD, Table.A, new DateTime(2014, 1, 23), 0.3939M },
                    new object[] { Currency.CAD, Table.A, new DateTime(2014, 1, 23), 2.7415M },
                    new object[] { Currency.NZD, Table.A, new DateTime(2014, 1, 23), 2.5432M },
                    new object[] { Currency.SGD, Table.A, new DateTime(2014, 1, 23), 2.3874M },
                    new object[] { Currency.EUR, Table.A, new DateTime(2014, 1, 23), 4.1679M },
                    new object[] { Currency.HUF, Table.A, new DateTime(2014, 1, 23), 1.3733M },
                    new object[] { Currency.CHF, Table.A, new DateTime(2014, 1, 23), 3.3843M },
                    new object[] { Currency.GBP, Table.A, new DateTime(2014, 1, 23), 5.0732M },
                    new object[] { Currency.UAH, Table.A, new DateTime(2014, 1, 23), 0.3629M },
                    new object[] { Currency.JPY, Table.A, new DateTime(2014, 1, 23), 2.9299M },
                    new object[] { Currency.CZK, Table.A, new DateTime(2014, 1, 23), 0.1516M },
                    new object[] { Currency.DKK, Table.A, new DateTime(2014, 1, 23), 0.5585M },
                    new object[] { Currency.ISK, Table.A, new DateTime(2014, 1, 23), 2.6497M },
                    new object[] { Currency.NOK, Table.A, new DateTime(2014, 1, 23), 0.4993M },
                    new object[] { Currency.SEK, Table.A, new DateTime(2014, 1, 23), 0.4747M },
                    new object[] { Currency.HRK, Table.A, new DateTime(2014, 1, 23), 0.5452M },
                    new object[] { Currency.RON, Table.A, new DateTime(2014, 1, 23), 0.9205M },
                    new object[] { Currency.BGN, Table.A, new DateTime(2014, 1, 23), 2.1310M },
                    new object[] { Currency.TRY, Table.A, new DateTime(2014, 1, 23), 1.3440M },
                    new object[] { Currency.LTL, Table.A, new DateTime(2014, 1, 23), 1.2071M },
                    new object[] { Currency.ILS, Table.A, new DateTime(2014, 1, 23), 0.8767M },
                    new object[] { Currency.CLP, Table.A, new DateTime(2014, 1, 23), 0.5634M },
                    new object[] { Currency.PHP, Table.A, new DateTime(2014, 1, 23), 0.0675M },
                    new object[] { Currency.MXN, Table.A, new DateTime(2014, 1, 23), 0.2290M },
                    new object[] { Currency.ZAR, Table.A, new DateTime(2014, 1, 23), 0.2796M },
                    new object[] { Currency.BRL, Table.A, new DateTime(2014, 1, 23), 1.2883M },
                    new object[] { Currency.MYR, Table.A, new DateTime(2014, 1, 23), 0.9175M },
                    new object[] { Currency.RUB, Table.A, new DateTime(2014, 1, 23), 0.0898M },
                    new object[] { Currency.IDR, Table.A, new DateTime(2014, 1, 23), 2.5500M },
                    new object[] { Currency.INR, Table.A, new DateTime(2014, 1, 23), 4.9300M },
                    new object[] { Currency.KRW, Table.A, new DateTime(2014, 1, 23), 0.2846M },
                    new object[] { Currency.CNY, Table.A, new DateTime(2014, 1, 23), 0.5052M },
                    new object[] { Currency.XDR, Table.A, new DateTime(2014, 1, 23), 4.7096M }
                };
            }
        }

        #endregion

        [Theory]
        [PropertyData("ActualExchangeRatesTestData")]
        public void NBPApi_providedCurrency_shouldReturnActualExchangeRate(Currency providedCurrency, decimal expectedExchangeRateValue)
        {
            // Arrange
            NBPApi sut = new NBPApi(_mockedNbpDataSource);

            // Act
            ExchangeRate exchangeRate = sut.GetActualExchangeRate(providedCurrency);

            // Assert
            Assert.Equal(expectedExchangeRateValue, exchangeRate.Value);
        }

        [Theory]
        [PropertyData("ActualBuySellRatesTestData")]
        public void NBPApi_providedCurrency_shouldReturnActualBuySellRate(Currency providedCurrency, decimal expectedBuyRateValue, decimal expectedSellRateValue)
        {
            // Arrange
            NBPApi sut = new NBPApi(_mockedNbpDataSource);

            // Act
            BuySellRate buySellRate = sut.GetActualBuySellRate(providedCurrency);

            // Assert
            Assert.Equal(expectedBuyRateValue, buySellRate.BuyValue);
            Assert.Equal(expectedSellRateValue, buySellRate.SellValue);
        }

        [Theory]
        [PropertyData("ActualBaseRatesTestData")]
        public void NBPApi_providedRate_shouldReturnActualBaseRates(Rate rate, decimal value, DateTime ValidFrom)
        {
            // Arrange
            NBPApi sut = new NBPApi(_mockedNbpDataSource);

            // Act
            BaseRate baseRates = sut.GetActualBaseRate(rate);

            // Assert
            Assert.Equal(value, baseRates.Value);
            Assert.Equal(ValidFrom, baseRates.ValidFrom);
        }

        [Theory]
        [PropertyData("ArchivalExchangeRatesTestData")]
        public void NBPApi_providedCurrency_providedTable_providedDate_shouldReturnArchivalExchangeRate(Currency providedCurrency, Table providedTable, DateTime providedDate, decimal expectedExchangeRateValue)
        {
            // Arrange
            NBPApi sut = new NBPApi(_mockedNbpDataSource);

            // Act
            ExchangeRate exchangeRate = sut.GetArchivalExchangeRate(providedCurrency, providedTable, providedDate);

            // Assert
            Assert.Equal(expectedExchangeRateValue, exchangeRate.Value);
        }

        public void Dispose()
        {
            if (_mockedNbpDataSource != null)
                _mockedNbpDataSource.Dispose();
        }
    }
}