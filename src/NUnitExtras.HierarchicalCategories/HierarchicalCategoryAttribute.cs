using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Extras
{
    public class HierarchicalCategoryAttribute : NUnitAttribute, IApplyToTest
    {
        public HierarchicalCategoryAttribute()
            : this(null)
        {
        }

        public HierarchicalCategoryAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public void ApplyToTest(Test test)
        {
            string[] categories = Name == null
                ? HierarchicalCategoryResolver.ExtractCategories(GetType())
                : HierarchicalCategoryResolver.ExtractCategories(Name);

            foreach (string category in categories)
                test.Properties.Add(PropertyNames.Category, category);
        }
    }
}
