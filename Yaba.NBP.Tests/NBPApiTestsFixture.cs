using Moq;
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTestsFixture : IDisposable
    {
        private MemoryStream _mockedActualExchangeRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedActualBuySellRatesDataSourceStream = new MemoryStream();
        
        public NBPApiTestsFixture()
        {
            string mockedActualExchangeRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualExchangeRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedActualExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualExchangeRatesDataSourceStream);
            }

            string mockedActualbuySellRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualbuySellRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedActualbuySellRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualBuySellRatesDataSourceStream);
            }
        }

        public INBPDataSource GetMockedNBPDataSource()
        {
            Mock<INBPDataSource> mock = new Mock<INBPDataSource>();
            mock.Setup(m => m.GetActualExchangeRatesDataSource()).Returns(_mockedActualExchangeRatesDataSourceStream);
            mock.Setup(m => m.GetActualBuySellRatesDataSource()).Returns(_mockedActualBuySellRatesDataSourceStream);
            return mock.Object;
        }

        public void Dispose()
        {
            if (_mockedActualExchangeRatesDataSourceStream != null)
                _mockedActualExchangeRatesDataSourceStream.Dispose();

            if (_mockedActualBuySellRatesDataSourceStream != null)
                _mockedActualBuySellRatesDataSourceStream.Dispose();
        }
    }
}