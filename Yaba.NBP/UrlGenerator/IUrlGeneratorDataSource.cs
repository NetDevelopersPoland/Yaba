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