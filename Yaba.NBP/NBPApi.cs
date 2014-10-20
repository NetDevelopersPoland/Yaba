// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
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

                var data = from item in xmlDocument.Descendants("pozycja")
                           where item.Element("kod_waluty").Value == Enum.GetName(currency.GetType(), currency)
                           select new
                           {
                               Published = DateTime.Parse(item.Parent.Element("data_publikacji").Value, ApiConfiguration.DefaultCulture),
                               Value = Decimal.Parse(item.Element("kurs_sredni").Value, ApiConfiguration.DefaultCulture),
                           };

                var tmp = data.FirstOrDefault();

                return new ExchangeRate()
                {
                    PublicationDate = tmp.Published,
                    Value = tmp.Value,
                    Currency = currency,
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

                var data = from item in xmlDocument.Descendants("pozycja")
                           where item.Element("kod_waluty").Value == Enum.GetName(currency.GetType(), currency)
                           select new
                           {
                               Published = DateTime.Parse(item.Parent.Element("data_publikacji").Value, ApiConfiguration.DefaultCulture),
                               BuyValue = Decimal.Parse(item.Element("kurs_kupna").Value, ApiConfiguration.DefaultCulture),
                               SellValue = Decimal.Parse(item.Element("kurs_sprzedazy").Value, ApiConfiguration.DefaultCulture),
                           };

                var tmp = data.FirstOrDefault();

                return new BuySellRate()
                {
                    PublicationDate = tmp.Published,
                    BuyValue = tmp.BuyValue,
                    SellValue = tmp.SellValue,
                    Currency = currency,
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

                var data = from item in
                               (from item1 in xmlDocument.Descendants("tabela")
                                where item1.Attribute("id").Value == "stoproc"
                                select item1.Descendants("pozycja")).FirstOrDefault()
                           where item.Attribute("id").Value == rate.GetId()
                           select new
                           {
                               ValidFrom = DateTime.Parse(item.Attribute("obowiazuje_od").Value, ApiConfiguration.DefaultCulture),
                               Value = Decimal.Parse(item.Attribute("oprocentowanie").Value, ApiConfiguration.DefaultCulture),
                           };

                var tmp = data.FirstOrDefault();

                return new BaseRate()
                {
                    Rate = rate,
                    Value = tmp.Value,
                    ValidFrom = tmp.ValidFrom
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

                var data = from item in xmlDocument.Descendants("pozycja")
                           where item.Element("kod_waluty").Value == Enum.GetName(currency.GetType(), currency)
                           select new
                           {
                               Published = DateTime.Parse(item.Parent.Element("data_publikacji").Value, ApiConfiguration.DefaultCulture),
                               Value = Decimal.Parse(item.Element("kurs_sredni").Value, ApiConfiguration.DefaultCulture),
                           };

                var tmp = data.FirstOrDefault();

                return new ExchangeRate()
                {
                    PublicationDate = tmp.Published,
                    Value = tmp.Value,
                    Currency = currency,
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

                var data = from item in xmlDocument.Descendants("pozycja")
                           where item.Element("kod_waluty").Value == Enum.GetName(currency.GetType(), currency)
                           select new
                           {
                               Published = DateTime.Parse(item.Parent.Element("data_publikacji").Value, ApiConfiguration.DefaultCulture),
                               BuyValue = Decimal.Parse(item.Element("kurs_kupna").Value, ApiConfiguration.DefaultCulture),
                               SellValue = Decimal.Parse(item.Element("kurs_sprzedazy").Value, ApiConfiguration.DefaultCulture),
                           };

                var tmp = data.FirstOrDefault();

                return new BuySellRate()
                {
                    PublicationDate = tmp.Published,
                    BuyValue = tmp.BuyValue,
                    SellValue = tmp.SellValue,
                    Currency = currency,
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