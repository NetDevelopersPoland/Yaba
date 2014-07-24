using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    internal static class ArchivalExchangeRatesUrlGenerator
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="date">Date</param>
        /// <returns></returns>
        public static string GetUrl(Table table, DateTime date)
        {
            string formattedDate = date.ToString("yyMMdd");
            string fileName = "";

            return string.Format(ApiConfiguration.ArchivalExchangeRatesDataSourceUrl, fileName);
        }
    }
}