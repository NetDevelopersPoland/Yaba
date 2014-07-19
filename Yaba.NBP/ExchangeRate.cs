using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// Exchange rate
    /// </summary>
    public struct ExchangeRate
    {
        /// <summary>
        /// Value
        /// </summary>
        public decimal Value { get; set; }

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