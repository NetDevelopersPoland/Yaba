using System;
using System.IO;
using System.Net;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    public class NBPDataSource : INBPDataSource
    {
        private HttpWebResponse _httpWebResponse;

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetActualExchangeRatesDataSource()
        {
            return GetStreamForUrl(ApiConfiguration.ActualExchangeRatesDataSourceUrl);
        }

        /// <summary>
        /// Provides actual buy-sell dates source
        /// </summary>
        /// <returns></returns>
        public Stream GetActualBuySellRatesDataSource()
        {
            return GetStreamForUrl(ApiConfiguration.ActualBuySellRatesDataSourceUrl);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetArchivalExchangeRatesDataSource(Table table, DateTime date)
        {
            return GetStreamForUrl(ArchivalExchangeRatesUrlGenerator.GetUrl(table, date));
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetActualBaseRatesDataSource()
        {
            return GetStreamForUrl(ApiConfiguration.ActualBaseRatesDataSourceUrl);
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