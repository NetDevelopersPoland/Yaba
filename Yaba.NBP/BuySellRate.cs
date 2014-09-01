// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
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