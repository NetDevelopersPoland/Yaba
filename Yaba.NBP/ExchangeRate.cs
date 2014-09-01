// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
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