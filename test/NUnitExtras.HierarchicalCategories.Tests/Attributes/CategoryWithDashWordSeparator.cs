namespace NUnitExtras.HierarchicalCategories.Tests;

[HierarchicalCategorySettings(WordSeparator = "-")]
public class CategoryWithDashWordSeparator : HierarchicalCategoryAttribute
{
    private CategoryWithDashWordSeparator()
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
