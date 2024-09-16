namespace NUnitExtras.HierarchicalCategories.Tests;

[HierarchicalCategorySettings(WordSeparator = null)]
public class CategoryWithNullWordSeparator : HierarchicalCategoryAttribute
{
    private CategoryWithNullWordSeparator()
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
