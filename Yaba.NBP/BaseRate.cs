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