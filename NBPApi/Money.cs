namespace DotNetDevelopersPL.Yaba
{
    /// <summary>
    /// Money
    /// </summary>
    public struct Money
    {
        /// <summary>
        /// Value
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Currency
        /// </summary>
        public Currency Currency { get; set; }
    }
}
