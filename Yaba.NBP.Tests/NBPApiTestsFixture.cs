using Moq;
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTestsFixture : IDisposable
    {
        private MemoryStream _mockedActualExchangeRatesDataSourceStream = new MemoryStream();
        private MemoryStream _mockedArchivalExchangeRatesDataSourceStream = new MemoryStream();

        public NBPApiTestsFixture()
        {
            string mockedActualExchangeRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualExchangeRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedActualExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualExchangeRatesDataSourceStream);
            }

            string mockedArchivalExchangeRatesDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedArchivalExchangeRatesDataSource.xml";
            using (FileStream tempStream = File.Open(mockedArchivalExchangeRatesDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedArchivalExchangeRatesDataSourceStream);
            }
        }

        public INBPDataSource GetMockedNBPDataSource()
        {
            Mock<INBPDataSource> mock = new Mock<INBPDataSource>();
            mock.Setup(m => m.GetActualExchangeRatesDataSource()).Returns(_mockedActualExchangeRatesDataSourceStream);
            mock.Setup(m => m.GetArchivalExchangeRatesDataSource(Table.A, new DateTime(2014, 1, 23))).Returns(_mockedArchivalExchangeRatesDataSourceStream);
            return mock.Object;
        }

        public void Dispose()
        {
            if (_mockedActualExchangeRatesDataSourceStream != null)
                _mockedActualExchangeRatesDataSourceStream.Dispose();
            if (_mockedArchivalExchangeRatesDataSourceStream != null)
                _mockedArchivalExchangeRatesDataSourceStream.Dispose();
        }
    }
}