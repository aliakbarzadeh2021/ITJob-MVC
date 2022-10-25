using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using ITJob.Infrastructure.Services;

namespace ITJob.Infrastructure.Utility
{
    /// <summary>
    /// کلاس کمکی برای کار با انومریشن ها
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static string GetEnumDisplay<TEnum>(TEnum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            var attributes = (DisplayAttribute[])fi.GetCustomAttributes(typeof(DisplayAttribute), false);


            if ((attributes.Length > 0))
            {
                var attrDisplay = attributes[0];
                if (attrDisplay.ResourceType == null) return attrDisplay.Name;
                return attrDisplay.ResourceType.GetProperty(attrDisplay.Name).GetValue(null, null).ToString();
            }
            else
                return value.ToString();
        }


        public static string GetPersianText(Enum e)
        {
            return GetPersianText(e.ToString());
        }
        public static string GetPersianText(string s)
        {
            return s.Replace("_", " ");
        }

        public static IEnumerable<KeyValueObject> GetKeyValueObjectList<T>()
        {
            Array values = Enum.GetValues(typeof(T));

            IList<KeyValueObject> result = new List<KeyValueObject>();
            foreach (int value in values)
                result.Add(new KeyValueObject(value, GetPersianText(Enum.GetName(typeof(T), value))));

            return result;
        }

    }
}
