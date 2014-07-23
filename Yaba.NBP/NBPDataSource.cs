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
            string actualExchangeRatesDataSourceUrl = ApiConfiguration.ActualExchangeRatesDataSourceUrl;
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(actualExchangeRatesDataSourceUrl);
            _httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            return _httpWebResponse.GetResponseStream();
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetArchivalExchangeRatesDataSource(Table table, DateTime date)
        {
            string archivalExchangeRatesDataSourceUrl = ArchivalExchangeRatesUrlGenerator.GetUrl(table, date);
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(archivalExchangeRatesDataSourceUrl);
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