namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// Rates
    /// </summary>
    public enum Rate
    {
        /// <summary>
        /// Reference rate (minimum money market intervention rate)
        /// </summary>
        [Id("ref")]
        Reference,
        /// <summary>
        /// Lombard rate
        /// </summary>
        [Id("lom")]
        Lombard,
        /// <summary>
        /// NBP deposit rate
        /// </summary>
        [Id("dep")]
        Deposit,
        /// <summary>
        /// Rediscount rate
        /// </summary>
        [Id("red")]
        Rediscount
    }
}