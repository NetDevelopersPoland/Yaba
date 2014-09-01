// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
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
                throw new ArgumentException("Date must be greater than or equal to 02.01.2002");
            if (date >= DateTime.Now.Date)
                throw new ArgumentException("Date must be earlier than current date");

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

        /// <summary>
        /// Get archival data source prefix
        /// </summary>
        /// <example>a</example>
        /// <example>b</example>
        /// <example>c</example>
        /// <example>h</example>
        private static string GetArchivalDataSourcePrefix(Table table)
        {
            return Enum.GetName(table.GetType(), table).ToLower();
        }

        /// <summary>
        /// Get archival data source suffix
        /// </summary>
        /// <example>z140801</example>
        /// <example>z081228</example>
        /// <example>z030201</example>
        /// <example>z110914</example>
        private static string GetArchivalDataSourceSuffix(DateTime date)
        {
            return "z" + date.ToString("yyMMdd");
        }
    }
}