using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    public class NBPApi : INBPApi, IDisposable
    {
        private string _requestUriString;

        /// <summary>
        /// Creates new NBPApi instance
        /// </summary>
        public NBPApi()
        {
            _requestUriString = ConfigurationManager.AppSettings["NBPUrl"];
        }

        /// <summary>
        /// Get actual exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Actual exchange rate for currency</returns>
        public Money GetActualExchangeRate(Currency currency)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(_requestUriString);

            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("iso-8859-2")))
                {
                    // TODO

                    return new Money()
                    {
                        Value = 1M,
                        Currency = currency
                    };
                }
            }
        }
        
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            // TODO
        }
    }
}
