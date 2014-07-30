using System.IO;
using System.Net;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    internal class UrlGeneratorDataSource : IUrlGeneratorDataSource
    {
        private HttpWebResponse _httpWebResponse;

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetArchivalDataSourcesList()
        {
            return GetStreamForUrl(ApiConfiguration.ArchivalDataSourcesListUrl);
        }

        private Stream GetStreamForUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            _httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            return _httpWebResponse.GetResponseStream();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_httpWebResponse != null)
                _httpWebResponse.Dispose();
        }
    }
}