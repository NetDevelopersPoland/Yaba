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
        /// TODO
        /// </summary>
        /// <param name="archivalDataSourcesList"></param>
        /// <param name="archivalDataSourcePrefix"></param>
        /// <param name="archivalDataSourceSuffix"></param>
        /// <returns></returns>
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