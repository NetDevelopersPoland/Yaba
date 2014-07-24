using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    public class NBPApi : INBPApi, IDisposable
    {
        private INBPDataSource _NBPDataSource;

        /// <summary>
        /// Creates new NBPApi instance
        /// </summary>
        public NBPApi()
        {
            _NBPDataSource = new NBPDataSource();
        }

        /// <summary>
        /// Creates new NBPApi instance
        /// </summary>
        public NBPApi(INBPDataSource NBPDataSource)
        {
            _NBPDataSource = NBPDataSource;
        }

        /// <summary>
        /// Get actual exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Actual exchange rate for currency</returns>
        public ExchangeRate GetActualExchangeRate(Currency currency)
        {
            Stream actualExchangeRatesDataSourceStream = _NBPDataSource.GetActualExchangeRatesDataSource();
            if (actualExchangeRatesDataSourceStream.CanSeek)
                actualExchangeRatesDataSourceStream.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            actualExchangeRatesDataSourceStream.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, Encoding.GetEncoding("iso-8859-2")))
            {
                XDocument xmlDocument = XDocument.Load(new StringReader(streamReader.ReadToEnd()));
                XElement positionElement = xmlDocument
                    .Descendants(XName.Get("kod_waluty"))
                    .SingleOrDefault(x => x.Value == Enum.GetName(currency.GetType(), currency))
                    .Parent;
                XElement valueElement = positionElement
                    .Elements(XName.Get("kurs_sredni"))
                    .SingleOrDefault();
                XElement publicationDateElement = xmlDocument
                    .Descendants(XName.Get("data_publikacji"))
                    .SingleOrDefault();

                Decimal value = Decimal.Parse(valueElement.Value, CultureInfo.GetCultureInfo("pl-PL"));
                DateTime publicationDate = DateTime.Parse(publicationDateElement.Value, CultureInfo.GetCultureInfo("pl-PL"));

                return new ExchangeRate()
                {
                    Value = value,
                    Currency = currency,
                    PublicationDate = publicationDate
                };
            }
        }

        /// <summary>
        /// Get actual buy-sell rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Return actual buy-sell rates for currency</returns>
        public BuySellRate GetActualBuySellRate(Currency currency)
        {
            Stream actualBuySellRatesDataSource = _NBPDataSource.GetActualBuySellRatesDataSource();
            if (actualBuySellRatesDataSource.CanSeek)
                actualBuySellRatesDataSource.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            actualBuySellRatesDataSource.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, Encoding.GetEncoding("iso-8859-2")))
            {
                XDocument xmlDocument = XDocument.Load(new StringReader(streamReader.ReadToEnd()));
                XElement positionElement = xmlDocument
                    .Descendants(XName.Get("kod_waluty"))
                    .SingleOrDefault(x => x.Value == Enum.GetName(currency.GetType(), currency))
                    .Parent;
                XElement buyValueElement = positionElement
                    .Elements(XName.Get("kurs_kupna"))
                    .SingleOrDefault();
                XElement sellValueElement = positionElement
                    .Elements(XName.Get("kurs_sprzedazy"))
                    .SingleOrDefault();
                XElement publicationDateElement = xmlDocument
                    .Descendants(XName.Get("data_publikacji"))
                    .SingleOrDefault();

                Decimal buyValue = Decimal.Parse(buyValueElement.Value, CultureInfo.GetCultureInfo("pl-PL"));
                Decimal sellValue = Decimal.Parse(sellValueElement.Value, CultureInfo.GetCultureInfo("pl-PL"));
                DateTime publicationDate = DateTime.Parse(publicationDateElement.Value, CultureInfo.GetCultureInfo("pl-PL"));

                return new BuySellRate()
                {
                    BuyValue = buyValue,
                    SellValue = sellValue,
                    Currency = currency,
                    PublicationDate = publicationDate
                };
            }
        }

        /// <summary>
        /// Get archival exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="table">Table</param>
        /// <param name="date">Date</param>
        /// <returns>Archival exchange rate for currency</returns>
        public ExchangeRate GetArchivalExchangeRate(Currency currency, Table table, DateTime date)
        {
            // TODO

            return new ExchangeRate();
        }




        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_NBPDataSource != null)
                _NBPDataSource.Dispose();
        }
    }
}