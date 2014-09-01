// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// NBPApi interface
    /// </summary>
    public interface INBPApi
    {
        /// <summary>
        /// Get actual exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Actual exchange rate for currency</returns>
        ExchangeRate GetActualExchangeRate(Currency currency);

        /// <summary>
        /// Get actual buy-sell rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Actual buy-sell rate for currency</returns>
        BuySellRate GetActualBuySellRate(Currency currency);

        /// <summary>
        /// Get actual base rate
        /// </summary>
        /// <param name="rate">Rate type</param>
        /// <returns>Actual rate</returns>
        BaseRate GetActualBaseRate(Rate rate);

        /// <summary>
        /// Get archival exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="date">Date</param>
        /// <returns>Archival exchange rate for currency</returns>
        ExchangeRate GetArchivalExchangeRate(Currency currency, DateTime date);

        /// <summary>
        /// Get archival buy-sell rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="date">Date</param>
        /// <returns>Archival buy-sell rate for currency</returns>
        BuySellRate GetArchivalBuySellRate(Currency currency, DateTime date);
    }
}