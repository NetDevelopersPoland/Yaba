using System;

namespace NetDevelopersPoland.Yaba.NBP
{
    public struct BaseRate
    {
        public Rate Rate { get; set; }
        public decimal Value { get; set; }
        public DateTime ValidFrom { get; set; }
    }
}