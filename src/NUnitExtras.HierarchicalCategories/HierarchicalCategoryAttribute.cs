using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Extras
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true)]
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
            {
                if (!test.Properties[PropertyNames.Category].Contains(category))
                    test.Properties.Add(PropertyNames.Category, category);
            }
        }
    }
}
