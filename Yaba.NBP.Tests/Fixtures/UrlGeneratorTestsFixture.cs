using Moq;
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP.Tests.Fixtures
{
    public class UrlGeneratorTestsFixture : IDisposable
    {
        private MemoryStream _mockedArchivalDataSourcesListStream = new MemoryStream();

        public UrlGeneratorTestsFixture()
        {
            string mockedArchivalDataSourcesListFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Mocks", "MockedArchivalDataSourcesList.txt");
            using (FileStream tempStream = File.Open(mockedArchivalDataSourcesListFilePath, FileMode.Open))
            {
                tempStream.CopyTo(_mockedArchivalDataSourcesListStream);
            }
        }

        public IUrlGeneratorDataSource GetMockedUrlGeneratorDataSource()
        {
            Mock<IUrlGeneratorDataSource> mock = new Mock<IUrlGeneratorDataSource>();

            mock.Setup(m => m.GetArchivalDataSourcesList()).Returns(_mockedArchivalDataSourcesListStream);

            return mock.Object;
        }

        public void Dispose()
        {
            if (_mockedArchivalDataSourcesListStream != null)
                _mockedArchivalDataSourcesListStream.Dispose();
        }
    }
}