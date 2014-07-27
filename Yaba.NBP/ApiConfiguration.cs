﻿using System.Configuration;
using System.Globalization;
using System.Text;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// API configuration
    /// </summary>
    internal static class ApiConfiguration
    {
        /// <summary>
        /// Default encoding
        /// </summary>
        public static Encoding DefaultEncoding
        {
            get { return Encoding.GetEncoding("iso-8859-2"); }
        }

        /// <summary>
        /// Default culture
        /// </summary>
        public static CultureInfo DefaultCulture
        {
            get { return CultureInfo.GetCultureInfo("pl-PL"); }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static string AvailableFilesList
        {
            get { return ConfigurationManager.AppSettings["AvailableFilesList"].ToString(); }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static string ActualExchangeRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ActualExchangeRatesDataSourceUrl"].ToString(); }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static string ActualBuySellRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ActualBuySellRatesDataSourceUrl"].ToString(); }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static string ActualBaseRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ActualBaseRatesDataSourceUrl"].ToString(); }
        }

        /// <summary>
        /// TODO
        /// </summary>
        public static string ArchivalExchangeRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ArchivalExchangeRatesDataSourceUrl"].ToString(); }
        }
    }
}