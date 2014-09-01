// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    internal interface INBPDataSource : IDisposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetActualExchangeRatesDataSource();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetActualBuySellRatesDataSource();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetActualBaseRatesDataSource();

        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetArchivalDataSource(Table table, DateTime date);
    }
}