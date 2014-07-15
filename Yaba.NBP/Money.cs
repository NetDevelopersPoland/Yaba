using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// Money
    /// </summary>
    public struct Money
    {
        /// <summary>
        /// Exchange rate
        /// </summary>
        public decimal ExchangeRate { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public Currency Currency { get; set; }

        /// <summary>
        /// Publication date
        /// </summary>
        public DateTime PublicationDate { get; set; }
    }
}
