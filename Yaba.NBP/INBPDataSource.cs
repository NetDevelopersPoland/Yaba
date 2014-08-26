using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    internal interface INBPDataSource : IDisposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetActualExchangeRatesDataSource();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetActualBuySellRatesDataSource();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetActualBaseRatesDataSource();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetArchivalDataSource(Table table, DateTime date);
    }
}