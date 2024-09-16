using NUnit.Extras;
using NUnit.Framework.Internal;

namespace NUnitExtras.HierarchicalCategories.Tests;

[HierarchicalCategorySettings(
    ApplyTopLevelToTestProperties = [TopLevelPropertyName],
    ApplyEachLevelToTestProperties = [PropertyNames.Category, EachLevelPropertyName])]
public static class HybridCategory
{
    public const string TopLevelPropertyName = "HybridProperty";

    public const string EachLevelPropertyName = "HybridCategory";

    public class Level1 : HierarchicalCategoryAttribute
    {
        public class Level1_1 : HierarchicalCategoryAttribute
        {
        }

        public class Level1_2 : HierarchicalCategoryAttribute
        {
        }
    }
}
