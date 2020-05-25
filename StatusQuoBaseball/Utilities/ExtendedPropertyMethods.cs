using System;
using System.Collections.Generic;
using System.Reflection;

namespace StatusQuoBaseball.Utilities
{
    /// <summary>
    /// Extended property methods.
    /// </summary>
    public static class ExtendedPropertyMethods
    {
        /// <summary>
        /// Gets the property value.
        /// </summary>
        /// <returns>The property value.</returns>
        /// <param name="obj">object</param>
        /// <param name="name">string</param>
        public static Object GetPropValue(this Object obj, String name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        /// <summary>
        /// Gets the property value of the provided property.
        /// </summary>
        /// <returns>The property value.</returns>
        /// <param name="obj">object</param>
        /// <param name="name">string</param>
        /// <typeparam name="T">T.</typeparam>
        public static T GetPropValue<T>(this Object obj, String name)
        {
            Object retval = GetPropValue(obj, name);
            if (retval == null) { return default(T); }

            // throws InvalidCastException if types are incompatible
            return (T)retval;
        }
    }
}
