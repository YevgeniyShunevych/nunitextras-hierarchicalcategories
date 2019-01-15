using System;
using System.Linq;
using System.Reflection;

namespace NUnit.Extras
{
    internal static class ICustomAttributeProviderExtensions
    {
        internal static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider provider, bool inherit = true)
            where TAttribute : Attribute
        {
            return provider.GetCustomAttributes(typeof(TAttribute), inherit).
                FirstOrDefault() as TAttribute;
        }

        internal static bool TryGetAttribute<TAttribute>(this ICustomAttributeProvider provider, out TAttribute attribute)
            where TAttribute : Attribute
        {
            return provider.TryGetAttribute(true, out attribute);
        }

        internal static bool TryGetAttribute<TAttribute>(this ICustomAttributeProvider provider, bool inherit, out TAttribute attribute)
            where TAttribute : Attribute
        {
            attribute = provider.GetAttribute<TAttribute>(inherit);
            return attribute != null;
        }
    }
}
