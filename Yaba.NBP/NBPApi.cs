using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    public class NBPApi : INBPApi, IDisposable
    {
        private INBPDataSource _nbpDataSource;

        /// <summary>
        /// Creates new NBPApi instance
        /// </summary>
        public NBPApi()
            : this(new NBPDataSource())
        {
        }

        /// <summary>
        /// Creates new NBPApi instance
        /// </summary>
        internal NBPApi(INBPDataSource nbpDataSource)
        {
            _nbpDataSource = nbpDataSource;
        }

        /// <summary>
        /// Get actual exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Actual exchange rate for currency</returns>
        public ExchangeRate GetActualExchangeRate(Currency currency)
        {
            Stream actualExchangeRatesDataSourceStream = _nbpDataSource.GetActualExchangeRatesDataSource();
            if (actualExchangeRatesDataSourceStream.CanSeek)
                actualExchangeRatesDataSourceStream.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            actualExchangeRatesDataSourceStream.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, ApiConfiguration.DefaultEncoding))
            {
                XDocument xmlDocument = XDocument.Load(streamReader);

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

                decimal value = Decimal.Parse(valueElement.Value, ApiConfiguration.DefaultCulture);
                DateTime publicationDate = DateTime.Parse(publicationDateElement.Value, ApiConfiguration.DefaultCulture);

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
            Stream actualBuySellRatesDataSource = _nbpDataSource.GetActualBuySellRatesDataSource();
            if (actualBuySellRatesDataSource.CanSeek)
                actualBuySellRatesDataSource.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            actualBuySellRatesDataSource.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, ApiConfiguration.DefaultEncoding))
            {
                XDocument xmlDocument = XDocument.Load(streamReader);

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

                decimal buyValue = Decimal.Parse(buyValueElement.Value, ApiConfiguration.DefaultCulture);
                decimal sellValue = Decimal.Parse(sellValueElement.Value, ApiConfiguration.DefaultCulture);
                DateTime publicationDate = DateTime.Parse(publicationDateElement.Value, ApiConfiguration.DefaultCulture);

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
        /// Get actual base rate
        /// </summary>
        /// <param name="rate">Rate type</param>
        /// <returns>Actual rate</returns>
        public BaseRate GetActualBaseRate(Rate rate)
        {
            Stream actualBaseRatesDataSourceStream = _nbpDataSource.GetActualBaseRatesDataSource();
            if (actualBaseRatesDataSourceStream.CanSeek)
                actualBaseRatesDataSourceStream.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            actualBaseRatesDataSourceStream.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, ApiConfiguration.DefaultEncoding))
            {
                XDocument xmlDocument = XDocument.Load(streamReader);

                var result = xmlDocument.Element("stopy_procentowe")
                   .Elements("tabela")
                   .Single(x => (string)x.Attribute("id") == "stoproc");

                var positionElement = result
                    .Elements("pozycja")
                    .Single(x => (string)x.Attribute("id") == rate.GetId());


                var valueElement = positionElement.Attribute(XName.Get("oprocentowanie"));

                var validFromElement = positionElement.Attribute(XName.Get("obowiazuje_od"));

                decimal value = Decimal.Parse(valueElement.Value, ApiConfiguration.DefaultCulture);
                DateTime validFrom = DateTime.Parse(validFromElement.Value, ApiConfiguration.DefaultCulture);

                return new BaseRate()
                {
                    Rate = rate,
                    Value = value,
                    ValidFrom = validFrom
                };
            }
        }

        /// <summary>
        /// Get archival exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="date">Date</param>
        /// <returns>Archival exchange rate for currency</returns>
        public ExchangeRate GetArchivalExchangeRate(Currency currency, DateTime date)
        {
            Stream archivalExchangeRatesDataSourceStream = _nbpDataSource.GetArchivalDataSource(Table.A, date);
            if (archivalExchangeRatesDataSourceStream.CanSeek)
                archivalExchangeRatesDataSourceStream.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            archivalExchangeRatesDataSourceStream.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, ApiConfiguration.DefaultEncoding))
            {
                XDocument xmlDocument = XDocument.Load(streamReader);

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

                decimal value = Decimal.Parse(valueElement.Value, ApiConfiguration.DefaultCulture);
                DateTime publicationDate = DateTime.Parse(publicationDateElement.Value, ApiConfiguration.DefaultCulture);

                return new ExchangeRate()
                {
                    Value = value,
                    Currency = currency,
                    PublicationDate = publicationDate
                };
            }
        }

        /// <summary>
        /// Get archival buy-sell rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="date">Date</param>
        /// <returns>Archival buy-sell rate for currency</returns>
        public BuySellRate GetArchivalBuySellRate(Currency currency, DateTime date)
        {
            Stream archivalBuySellRatesDataSourceStream = _nbpDataSource.GetArchivalDataSource(Table.C, date);
            if (archivalBuySellRatesDataSourceStream.CanSeek)
                archivalBuySellRatesDataSourceStream.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            archivalBuySellRatesDataSourceStream.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, ApiConfiguration.DefaultEncoding))
            {
                XDocument xmlDocument = XDocument.Load(streamReader);

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

                decimal buyValue = Decimal.Parse(buyValueElement.Value, ApiConfiguration.DefaultCulture);
                decimal sellValue = Decimal.Parse(sellValueElement.Value, ApiConfiguration.DefaultCulture);
                DateTime publicationDate = DateTime.Parse(publicationDateElement.Value, ApiConfiguration.DefaultCulture);

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
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_nbpDataSource != null)
                _nbpDataSource.Dispose();
        }
    }
}