using NetDevelopersPoland.Yaba.NBP.Tests.Fixtures;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Extensions;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class UrlGeneratorTests : IUseFixture<UrlGeneratorTestsFixture>, IDisposable
    {
        private IUrlGeneratorDataSource _mockedUrlGeneratorDataSource;

        public void SetFixture(UrlGeneratorTestsFixture fixture)
        {
            _mockedUrlGeneratorDataSource = fixture.GetMockedUrlGeneratorDataSource();
        }

        #region Test data

        public static IEnumerable<object[]> CorrectTestData
        {
            get
            {
                return new[]
                {
                    new object[] { Table.A, new DateTime(2014, 7, 2),  "http://www.nbp.pl/kursy/xml/a126z140702.xml" },
                    new object[] { Table.A, new DateTime(2014, 6, 29), "http://www.nbp.pl/kursy/xml/a123z140627.xml" },
                    new object[] { Table.B, new DateTime(2014, 7, 2),  "http://www.nbp.pl/kursy/xml/b026z140702.xml" },
                    new object[] { Table.B, new DateTime(2014, 6, 29), "http://www.nbp.pl/kursy/xml/b025z140625.xml" },
                    new object[] { Table.C, new DateTime(2014, 7, 2),  "http://www.nbp.pl/kursy/xml/c126z140702.xml" },
                    new object[] { Table.C, new DateTime(2014, 6, 29), "http://www.nbp.pl/kursy/xml/c123z140627.xml" },
                    new object[] { Table.H, new DateTime(2014, 7, 2),  "http://www.nbp.pl/kursy/xml/h126z140702.xml" },
                    new object[] { Table.H, new DateTime(2014, 6, 29), "http://www.nbp.pl/kursy/xml/h123z140627.xml" }
                };
            }
        }

        public static IEnumerable<object[]> IncorrectTestData
        {
            get
            {
                return new[]
                {
                    new object[] { Table.A, new DateTime(2001, 12, 31) },
                    new object[] { Table.A, new DateTime(2002, 1, 1) },
                    new object[] { Table.A, DateTime.Now.Date },
                    new object[] { Table.A, DateTime.Now.Date.AddDays(1.0d) },
                    new object[] { Table.B, new DateTime(2001, 12, 31) },
                    new object[] { Table.B, new DateTime(2002, 1, 1) },
                    new object[] { Table.B, DateTime.Now.Date },
                    new object[] { Table.B, DateTime.Now.Date.AddDays(1.0d) },
                    new object[] { Table.C, new DateTime(2001, 12, 31) },
                    new object[] { Table.C, new DateTime(2002, 1, 1) },
                    new object[] { Table.C, DateTime.Now.Date },
                    new object[] { Table.C, DateTime.Now.Date.AddDays(1.0d) },
                    new object[] { Table.H, new DateTime(2001, 12, 31) },
                    new object[] { Table.H, new DateTime(2002, 1, 1) },
                    new object[] { Table.H, DateTime.Now.Date },
                    new object[] { Table.H, DateTime.Now.Date.AddDays(1.0d) }
                };
            }
        }

        #endregion

        [Theory]
        [PropertyData("CorrectTestData")]
        public void UrlGenerator_providedTable_providedDate_shouldReturnUrlToArchivalDataSource(Table providedTable, DateTime providedDate, string expectedUrl)
        {
            // Arrange
            UrlGenerator.SetMockedDataSource(_mockedUrlGeneratorDataSource);

            // Act
            string url = UrlGenerator.GetUrlToArchivalDataSource(providedTable, providedDate);

            // Assert
            Assert.Equal(expectedUrl, url);
        }

        [Theory]
        [PropertyData("IncorrectTestData")]
        public void UrlGenerator_providedTable_providedDate_shouldThrowArgumentException(Table providedTable, DateTime providedDate)
        {
            // Arrange
            UrlGenerator.SetMockedDataSource(_mockedUrlGeneratorDataSource);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => UrlGenerator.GetUrlToArchivalDataSource(providedTable, providedDate));
        }

        public void Dispose()
        {
            if (_mockedUrlGeneratorDataSource != null)
                _mockedUrlGeneratorDataSource.Dispose();
        }
    }
}