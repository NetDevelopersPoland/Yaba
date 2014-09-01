// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// Base rate
    /// </summary>
    public struct BaseRate
    {
        /// <summary>
        /// Rate
        /// </summary>
        public Rate Rate { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Valid from
        /// </summary>
        public DateTime ValidFrom { get; set; }
    }
}