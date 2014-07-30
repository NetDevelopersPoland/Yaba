using Moq;
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP.Tests.Fixtures
{
    public class NBPApiTestsFixture : IDisposable
    {
        private MemoryStream _mockedActualExchangeRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedActualBuySellRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedActualBaseRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedArchivalExchangeRatesDataSourceStream = new MemoryStream();

        public NBPApiTestsFixture()
        {
            string mockedActualExchangeRatesDataSourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mocks", "MockedActualExchangeRatesDataSource.xml");
            using (FileStream tempStream = File.Open(mockedActualExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualExchangeRatesDataSourceStream);
            }

            string mockedActualBuySellRatesDataSourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mocks", "MockedActualBuySellRatesDataSource.xml");
            using (FileStream tempStream = File.Open(mockedActualBuySellRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualBuySellRatesDataSourceStream);
            }

            string mockedActualBaseRatesDataSourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mocks", "MockedActualBaseRatesDataSource.xml");
            using (FileStream tempStream = File.Open(mockedActualBaseRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualBaseRatesDataSourceStream);
            }

            string mockedArchivalExchangeRatesDataSourceFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mocks", "MockedArchivalExchangeRatesDataSource.xml");
            using (FileStream tempStream = File.Open(mockedArchivalExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedArchivalExchangeRatesDataSourceStream);
            }
        }

        public INBPDataSource GetMockedNBPDataSource()
        {
            Mock<INBPDataSource> mock = new Mock<INBPDataSource>();

            mock.Setup(m => m.GetActualExchangeRatesDataSource()).Returns(_mockedActualExchangeRatesDataSourceStream);
            mock.Setup(m => m.GetActualBuySellRatesDataSource()).Returns(_mockedActualBuySellRatesDataSourceStream);
            mock.Setup(m => m.GetActualBaseRatesDataSource()).Returns(_mockedActualBaseRatesDataSourceStream);
            mock.Setup(m => m.GetArchivalDataSource(Table.A, new DateTime(2014, 1, 23))).Returns(_mockedArchivalExchangeRatesDataSourceStream);

            return mock.Object;
        }

        public void Dispose()
        {
            if (_mockedActualExchangeRatesDataSourceStream != null)
                _mockedActualExchangeRatesDataSourceStream.Dispose();
            if (_mockedActualBuySellRatesDataSourceStream != null)
                _mockedActualBuySellRatesDataSourceStream.Dispose();
            if (_mockedActualBaseRatesDataSourceStream != null)
                _mockedActualBaseRatesDataSourceStream.Dispose();
            if (_mockedArchivalExchangeRatesDataSourceStream != null)
                _mockedArchivalExchangeRatesDataSourceStream.Dispose();
        }
    }
}