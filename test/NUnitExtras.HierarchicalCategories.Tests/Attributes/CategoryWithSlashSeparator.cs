using NUnit.Extras;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    [HierarchicalCategorySettings(CategorySeparator = "/")]
    public class CategoryWithSlashSeparator : HierarchicalCategoryAttribute
    {
        private CategoryWithSlashSeparator()
        {
        }

        public class Child1 : HierarchicalCategoryAttribute
        {
            [HierarchicalCategoryName("Sub-child 1")]
            public class SubChild1 : HierarchicalCategoryAttribute
            {
            }
        }

        public class Child2 : HierarchicalCategoryAttribute
        {
        }
    }
}
