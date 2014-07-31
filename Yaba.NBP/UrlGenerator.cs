using System;
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
                string[] files = streamReader.ReadToEnd().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                string fileNamePrefix = GetFileNamePrefix(table);
                string fileNameSuffix = GetFileNameSuffix(date);
                string fileName = files.FirstOrDefault(file => file.StartsWith(fileNamePrefix) && file.EndsWith(fileNameSuffix));

                if (string.IsNullOrEmpty(fileName))
                {
                    do
                    {
                        date = date.AddDays(-1.0d);
                        if (date < ApiConfiguration.FirstArchivalDataSourceDate)
                            throw new ArgumentException();

                        fileNameSuffix = GetFileNameSuffix(date);
                        fileName = files.FirstOrDefault(file => file.StartsWith(fileNamePrefix) && file.EndsWith(fileNameSuffix));
                    }
                    while (string.IsNullOrEmpty(fileName));
                }

                return string.Format(ApiConfiguration.ArchivalDataSourceUrl, fileName);
            }
        }

        private static string GetFileNamePrefix(Table table)
        {
            return Enum.GetName(table.GetType(), table).ToLower();
        }

        private static string GetFileNameSuffix(DateTime date)
        {
            return "z" + date.ToString("yyMMdd");
        }
    }
}