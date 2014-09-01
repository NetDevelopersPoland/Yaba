// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
using System;
using System.Configuration;
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
        /// First archival data source date (02.01.2002)
        /// </summary>
        public static DateTime FirstArchivalDataSourceDate
        {
            get { return new DateTime(2002, 1, 2); }
        }

        /// <summary>
        /// URL to actual exchange rates data source
        /// </summary>
        public static string ActualExchangeRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ActualExchangeRatesDataSourceUrl"].ToString(); }
        }

        /// <summary>
        /// URL to actual buy-sell rates data source
        /// </summary>
        public static string ActualBuySellRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ActualBuySellRatesDataSourceUrl"].ToString(); }
        }

        /// <summary>
        /// URL to actual base rates data source
        /// </summary>
        public static string ActualBaseRatesDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ActualBaseRatesDataSourceUrl"].ToString(); }
        }

        /// <summary>
        /// URL to archival data sources list
        /// </summary>
        public static string ArchivalDataSourcesListUrl
        {
            get { return ConfigurationManager.AppSettings["ArchivalDataSourcesListUrl"].ToString(); }
        }

        /// <summary>
        /// URL to archival data source
        /// </summary>
        public static string ArchivalDataSourceUrl
        {
            get { return ConfigurationManager.AppSettings["ArchivalDataSourceUrl"].ToString(); }
        }
    }
}