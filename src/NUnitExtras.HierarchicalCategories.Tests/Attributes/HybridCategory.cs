using NUnit.Extras;
using NUnit.Framework.Internal;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    [HierarchicalCategorySettings(ApplyTopLevelsToTestProperties = new[] { TopLevelPropertyName }, ApplyAllLevelsToTestProperties = new[] { PropertyNames.Category, AllLevelsPropertyName })]
    public static class HybridCategory
    {
        public const string TopLevelPropertyName = "HybridProperty";

        public const string AllLevelsPropertyName = "HybridCategory";

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
}
