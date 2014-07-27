using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

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
            string fileNamePrefix = Enum.GetName(table.GetType(), table).ToLower();
            string fileNameSuffix = "z" + date.ToString("yyMMdd");

            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(ApiConfiguration.AvailableFilesList);
            using (HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                using (StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream(), ApiConfiguration.DefaultEncoding))
                {
                    string[] files = streamReader
                        .ReadToEnd()
                        .Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                    string fileName = files
                        .FirstOrDefault(file => file.StartsWith(fileNamePrefix) && file.EndsWith(fileNameSuffix));

                    if (string.IsNullOrEmpty(fileName))
                    {
                        DateTime tempDate = date;
                        do
                        {
                            tempDate = tempDate.AddDays(-1.0d);
                            fileNameSuffix = "z" + tempDate.ToString("yyMMdd");
                            fileName = files
                                .FirstOrDefault(file => file.StartsWith(fileNamePrefix) && file.EndsWith(fileNameSuffix));
                        }
                        while (string.IsNullOrEmpty(fileName));
                    }

                    return string.Format(ApiConfiguration.ArchivalExchangeRatesDataSourceUrl, fileName);
                }
            }
        }
    }
}