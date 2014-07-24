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
            return GetSteamForUrl(ApiConfiguration.ActualExchangeRatesDataSourceUrl);
        }

        /// <summary>
        /// Provides actual buy-sell dates source
        /// </summary>
        /// <returns></returns>
        public Stream GetActualBuySellRatesDataSource()
        {
            return GetSteamForUrl(ApiConfiguration.ActualBuySellRatesDataSourceUrl);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetArchivalExchangeRatesDataSource(Table table, DateTime date)
        {
            string archivalExchangeRatesDataSourceUrl = ArchivalExchangeRatesUrlGenerator.GetUrl(table, date);

            return GetSteamForUrl(archivalExchangeRatesDataSourceUrl);
        }

        private Stream GetSteamForUrl(string url)
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