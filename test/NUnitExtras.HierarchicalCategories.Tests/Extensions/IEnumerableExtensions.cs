using System.Collections;
using System.Linq;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    internal static class IEnumerableExtensions
    {
        internal static string[] ToStringArray(this IEnumerable enumerable) =>
            enumerable.Cast<string>().ToArray();
    }
}
