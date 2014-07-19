using Moq;
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP.Tests
{
    public class NBPApiTestsFixture : IDisposable
    {
        private MemoryStream _mockedActualExchangeRateDataSourceStream = new MemoryStream();
        
        public NBPApiTestsFixture()
        {
            string mockedActualExchangeRateDataSourceFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\MockedActualExchangeRateDataSource.xml";
            using (FileStream tempStream = File.Open(mockedActualExchangeRateDataSourceFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedActualExchangeRateDataSourceStream);
            }
        }

        public INBPDataSource GetMockedNBPDataSource()
        {
            Mock<INBPDataSource> mock = new Mock<INBPDataSource>();
            mock.Setup(m => m.GetActualExchangeRateDataSource()).Returns(_mockedActualExchangeRateDataSourceStream);
            return mock.Object;
        }

        public void Dispose()
        {
            if (_mockedActualExchangeRateDataSourceStream != null)
                _mockedActualExchangeRateDataSourceStream.Dispose();
        }
    }
}