using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface INBPDataSource : IDisposable
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
        Stream GetArchivalExchangeRatesDataSource(Table table, DateTime date);
    }
}