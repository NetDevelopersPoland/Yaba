using System.Collections.Generic;
using System.Linq;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// Extensions for URL generator
    /// </summary>
    public static class UrlGeneratorExtensions
    {
        /// <summary>
        /// Get archival data source by prefix and suffix
        /// </summary>
        /// <param name="archivalDataSourcesList">Archival data sources list</param>
        /// <param name="archivalDataSourcePrefix">Archival data source prefix</param>
        /// <param name="archivalDataSourceSuffix">Archival data source suffix</param>
        /// <returns>Archival data source</returns>
        public static string GetArchivalDataSource(this List<string> archivalDataSourcesList, string archivalDataSourcePrefix, string archivalDataSourceSuffix)
        {
            return archivalDataSourcesList
                .FirstOrDefault(dataSource =>
                    dataSource.StartsWith(archivalDataSourcePrefix) &&
                    dataSource.EndsWith(archivalDataSourceSuffix)
                );
        }
    }
}