using NUnit.Extras;

namespace NUnitExtras.HierarchicalCategories.Tests;

public static class Feature
{
    public class Analytics : HierarchicalCategoryAttribute
    {
        public class AssistedReview : HierarchicalCategoryAttribute
        {
        }

        public class Infrastructure : HierarchicalCategoryAttribute
        {
            public class Agents : HierarchicalCategoryAttribute
            {
            }

            public class Servers : HierarchicalCategoryAttribute
            {
                public class AnalyticsIndexing : HierarchicalCategoryAttribute
                {
                }

                public class StructuredData : HierarchicalCategoryAttribute
                {
                }
            }
        }
    }
}
