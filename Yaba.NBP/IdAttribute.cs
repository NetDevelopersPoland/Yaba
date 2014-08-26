using System;
using System.Reflection;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    internal class IdAttribute : Attribute
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        public IdAttribute(string id)
        {
            Value = id;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string Value { get; private set; }
    }

    /// <summary>
    /// TODO
    /// </summary>
    internal static class IdAttributeHelper
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetId(this object value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            string result = string.Empty;
            if (fi != null)
            {
                IdAttribute[] ids = (IdAttribute[])fi.GetCustomAttributes(typeof(IdAttribute), false);
                if (ids.Length > 0 && (!string.IsNullOrEmpty(ids[0].Value)))
                    result = ids[0].Value;
            }
            return result;
        }
    }
}