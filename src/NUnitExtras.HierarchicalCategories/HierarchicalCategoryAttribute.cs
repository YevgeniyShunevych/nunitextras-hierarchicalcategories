using System;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Extras
{
    /// <summary>
    /// Applies multiple hierarchical catregories to a test.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true)]
    public class HierarchicalCategoryAttribute : NUnitAttribute, IApplyToTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicalCategoryAttribute" /> class.
        /// Uses this type and all hierarchy of declaring types to build the hierarchical catregory name.
        /// </summary>
        protected HierarchicalCategoryAttribute()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicalCategoryAttribute" /> class.
        /// </summary>
        /// <param name="name">The hierarchical catregory name.</param>
        public HierarchicalCategoryAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the hierarchical catregory name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Extracts categories from hierarchical catregory name and adds them to a test.
        /// </summary>
        /// <param name="test">The test to modify</param>
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
