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
        /// Get archival exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="table">Table</param>
        /// <param name="date">Date</param>
        /// <returns>Archival exchange rate for currency</returns>
        ExchangeRate GetArchivalExchangeRate(Currency currency, Table table, DateTime date);

        /// <summary>
        /// Get actual base rate
        /// </summary>
        /// <param name="rate">Rate type</param>
        /// <returns>Actual rate</returns>
        BaseRate GetActualBaseRate(Rate rate);
    }
}