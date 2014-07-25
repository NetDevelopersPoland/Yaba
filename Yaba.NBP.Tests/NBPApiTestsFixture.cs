using Moq;
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTestsFixture : IDisposable
    {
        private MemoryStream _mockedActualExchangeRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedActualBuySellRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedArchivalExchangeRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedActualBaseRatesDataSourceStream = new MemoryStream();

        public NBPApiTestsFixture()
        {
            string mockedActualExchangeRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualExchangeRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedActualExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualExchangeRatesDataSourceStream);
            }

            string mockedActualBuySellRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualBuySellRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedActualBuySellRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualBuySellRatesDataSourceStream);
            }

            string mockedArchivalExchangeRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedArchivalExchangeRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedArchivalExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedArchivalExchangeRatesDataSourceStream);
            }

            string mockedActualBaseRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualBaseRates.xml";
            using (FileStream tempStream = File.Open(mockedActualBaseRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualBaseRatesDataSourceStream);
            }

        }

        public INBPDataSource GetMockedNBPDataSource()
        {
            Mock<INBPDataSource> mock = new Mock<INBPDataSource>();
            mock.Setup(m => m.GetActualExchangeRatesDataSource()).Returns(_mockedActualExchangeRatesDataSourceStream);
            mock.Setup(m => m.GetActualBuySellRatesDataSource()).Returns(_mockedActualBuySellRatesDataSourceStream);
            mock.Setup(m => m.GetArchivalExchangeRatesDataSource(Table.A, new DateTime(2014, 1, 23))).Returns(_mockedArchivalExchangeRatesDataSourceStream);
            mock.Setup(m => m.GetActualBaseRatesDataSource()).Returns(_mockedActualBaseRatesDataSourceStream);
            return mock.Object;
        }

        public void Dispose()
        {
            if (_mockedActualExchangeRatesDataSourceStream != null)
                _mockedActualExchangeRatesDataSourceStream.Dispose();
            if (_mockedActualBuySellRatesDataSourceStream != null)
                _mockedActualBuySellRatesDataSourceStream.Dispose();
            if (_mockedArchivalExchangeRatesDataSourceStream != null)
                _mockedArchivalExchangeRatesDataSourceStream.Dispose();
            if (_mockedActualBaseRatesDataSourceStream != null)
                _mockedActualBaseRatesDataSourceStream.Dispose();
        }
    }
}