using System;

namespace NetDevelopersPoland.Yaba.NBP
{   
    /// <summary>
    /// Buy-sell rates
    /// </summary>
    public class BuySellRate
    {
        /// <summary>
        /// Buy value
        /// </summary>
        public decimal BuyValue { get; set; }

        /// <summary>
        /// Sell value
        /// </summary>
        public decimal SellValue { get; set; }

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