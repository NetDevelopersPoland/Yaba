using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// URL generator
    /// </summary>
    internal static class UrlGenerator
    {
        private static IUrlGeneratorDataSource _urlGeneratorDataSource;

        static UrlGenerator()
        {
            _urlGeneratorDataSource = new UrlGeneratorDataSource();
        }

        internal static void SetMockedDataSource(IUrlGeneratorDataSource urlGeneratorDataSource)
        {
            _urlGeneratorDataSource = urlGeneratorDataSource;
        }

        /// <summary>
        /// Get URL to archival data source
        /// </summary>
        /// <param name="table">Table</param>
        /// <param name="date">Date</param>
        /// <returns>URL to archival data source</returns>
        public static string GetUrlToArchivalDataSource(Table table, DateTime date)
        {
            date = date.Date;

            if (date < ApiConfiguration.FirstArchivalDataSourceDate)
                throw new ArgumentException();
            if (date >= DateTime.Now.Date)
                throw new ArgumentException();

            Stream archivalDataSourcesListStream = _urlGeneratorDataSource.GetArchivalDataSourcesList();
            if (archivalDataSourcesListStream.CanSeek)
                archivalDataSourcesListStream.Seek(0, SeekOrigin.Begin);

            MemoryStream tempStream = new MemoryStream();
            archivalDataSourcesListStream.CopyTo(tempStream);
            if (tempStream.CanSeek)
                tempStream.Seek(0, SeekOrigin.Begin);

            using (StreamReader streamReader = new StreamReader(tempStream, ApiConfiguration.DefaultEncoding))
            {
                List<string> archivalDataSourcesList = streamReader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                string archivalDataSourcePrefix = GetArchivalDataSourcePrefix(table);
                string archivalDataSourceSuffix = GetArchivalDataSourceSuffix(date);
                string archivalDataSource = archivalDataSourcesList.GetArchivalDataSource(archivalDataSourcePrefix, archivalDataSourceSuffix);

                if (string.IsNullOrEmpty(archivalDataSource))
                {
                    do
                    {
                        date = date.AddDays(-1.0d);
                        if (date < ApiConfiguration.FirstArchivalDataSourceDate)
                            throw new ArgumentException();

                        archivalDataSourceSuffix = GetArchivalDataSourceSuffix(date);
                        archivalDataSource = archivalDataSourcesList.GetArchivalDataSource(archivalDataSourcePrefix, archivalDataSourceSuffix);
                    }
                    while (string.IsNullOrEmpty(archivalDataSource));
                }

                return string.Format(ApiConfiguration.ArchivalDataSourceUrl, archivalDataSource);
            }
        }

        private static string GetArchivalDataSourcePrefix(Table table)
        {
            return Enum.GetName(table.GetType(), table).ToLower();
        }

        private static string GetArchivalDataSourceSuffix(DateTime date)
        {
            return "z" + date.ToString("yyMMdd");
        }
    }
}