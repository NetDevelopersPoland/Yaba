using System;

namespace DotNetDevelopersPL.Yaba
{
    /// <summary>
    /// TODO
    /// </summary>
    public class NBPApi : INBPApi, IDisposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="currency">Currency</param>
        /// <returns>Actual exchange rate for currency</returns>
        public Money GetActualExchangeRate(Currency currency)
        {
            // TODO

            return new Money()
            {
                Value = 0M,
                Currency = currency
            };
        }
        
        /// <summary>
        /// TODO
        /// </summary>
        public void Dispose()
        {
            // TODO
        }
    }
}
