using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

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
            using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), Encoding.GetEncoding("iso-8859-2")))
            {
                XDocument xmlDocument = XDocument.Load(new StringReader(streamReader.ReadToEnd()));
                XElement positionElement = xmlDocument
                    .Descendants(XName.Get("kod_waluty"))
                    .SingleOrDefault(x => x.Value == Enum.GetName(currency.GetType(), currency))
                    .Parent;
                XElement exchangeRateElement = positionElement
                    .Elements(XName.Get("kurs_sredni"))
                    .SingleOrDefault();
                XElement publicationDateElement = xmlDocument
                    .Descendants(XName.Get("data_publikacji"))
                    .SingleOrDefault();

                Decimal value = Decimal.Parse(exchangeRateElement.Value);
                DateTime date = DateTime.Parse(publicationDateElement.Value);

                return new Money()
                {
                    ExchangeRate = value,
                    Currency = currency,
                    PublicationDate = date
                };
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
