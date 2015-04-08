// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
using System;
using System.IO;
using System.Net;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    internal class NBPDataSource : INBPDataSource
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
        public Stream GetActualBaseRatesDataSource()
        {
            return GetStreamForUrl(ApiConfiguration.ActualBaseRatesDataSourceUrl);
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        public Stream GetArchivalDataSource(Table table, DateTime date)
        {
            return GetStreamForUrl(UrlGenerator.GetUrlToArchivalDataSource(table, date));
        }

        private Stream GetStreamForUrl(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.Proxy = WebRequest.DefaultWebProxy;
            httpWebRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
            httpWebRequest.Proxy.Credentials = System.Net.CredentialCache.DefaultCredentials;
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