using System;
using System.Reflection;

namespace NetDevelopersPoland.Yaba.NBP
{
    /// <summary>
    /// TODO
    /// </summary>
    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
    public class IdAttribute : Attribute
    {
        public IdAttribute(string id)
        {
            Value = id;
        }
        public string Value { get; private set; }
    }

    public static class IdAttributeHelper
    {
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