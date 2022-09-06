using System.ComponentModel;
using System.Reflection;

namespace PetDesk.Abnoan.Application.Util
{
    public static class EnumExtensionMethods
    {
        public static string ToDescriptionString(this Enum enumValue)
        {
            if (enumValue is null) 
                return null;
          
            Type enumType = enumValue.GetType();
            MemberInfo[] memberInfo = enumType.GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                var attributes = memberInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0)                
                    return ((DescriptionAttribute)attributes.ElementAt(0)).Description;
                
            }

            return enumValue.ToString();
        }

        public static T ToEnum<T>(this string value, bool ignoreCase = true)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase);
        }
    }
}
