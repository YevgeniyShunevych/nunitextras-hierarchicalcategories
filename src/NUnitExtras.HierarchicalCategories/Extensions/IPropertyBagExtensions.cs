using System.Collections.Generic;
using NUnit.Framework.Interfaces;

namespace NUnit.Extras
{
    internal static class IPropertyBagExtensions
    {
        internal static void AddCrossJoinedRange(this IPropertyBag propertyBag, IEnumerable<string> keys, IEnumerable<string> values)
        {
            foreach (string key in keys)
            {
                foreach (string value in values)
                {
                    if (!propertyBag[key].Contains(value))
                        propertyBag.Add(key, value);
                }
            }
        }
    }
}
