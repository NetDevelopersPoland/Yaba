// Copyright 2014, NetDevelopersPoland. All rights reserved.
// Licensed under the MIT License. See License file in the project root for license information.
using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    internal interface IUrlGeneratorDataSource : IDisposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetArchivalDataSourcesList();
    }
}