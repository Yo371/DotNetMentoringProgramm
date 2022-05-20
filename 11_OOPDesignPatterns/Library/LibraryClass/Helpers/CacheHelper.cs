using System.Reflection;
using LibraryClass.Attributes;

namespace LibraryClass.Helpers
{
    public class CacheHelper
    {
        public static bool IsCacheable(object obj) => AttributeHelper.IsMarkedByAttribute(obj, typeof(CacheableAttribute));

        public static long GetTimeout(object obj) =>
            obj.GetType().GetCustomAttribute<CacheableAttribute>()?.TimeoutSeconds ?? 0;
    }
}
