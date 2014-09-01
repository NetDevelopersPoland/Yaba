// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
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