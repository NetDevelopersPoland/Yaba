using System;
using System.IO;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    public interface IUrlGeneratorDataSource : IDisposable
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <returns></returns>
        Stream GetArchivalDataSourcesList();
    }
}