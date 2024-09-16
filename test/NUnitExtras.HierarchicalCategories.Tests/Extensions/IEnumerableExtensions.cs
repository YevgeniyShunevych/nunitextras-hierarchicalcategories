using System.Collections;

namespace NUnitExtras.HierarchicalCategories.Tests;

internal static class IEnumerableExtensions
{
    internal static string[] ToStringArray(this IEnumerable enumerable) =>
        enumerable.Cast<string>().ToArray();
}
