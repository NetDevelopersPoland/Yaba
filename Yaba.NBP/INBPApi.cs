using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
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
        /// Get archival exchange rate for currency
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <param name="table">Table</param>
        /// <param name="date">Date</param>
        /// <returns>Archival exchange rate for currency</returns>
        ExchangeRate GetArchivalExchangeRate(Currency currency, Table table, DateTime date);
    }
}