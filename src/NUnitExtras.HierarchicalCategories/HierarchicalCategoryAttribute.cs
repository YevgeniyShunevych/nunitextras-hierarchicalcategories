using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Extras
{
    /// <summary>
    /// Applies single or multiple hierarchical categories to a test.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Assembly, AllowMultiple = true)]
    public class HierarchicalCategoryAttribute : NUnitAttribute, IApplyToTest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicalCategoryAttribute" /> class.
        /// Uses this type and all hierarchy of declaring types to build the hierarchical category name.
        /// </summary>
        protected HierarchicalCategoryAttribute()
            : this(null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HierarchicalCategoryAttribute" /> class.
        /// </summary>
        /// <param name="name">The hierarchical category name.</param>
        public HierarchicalCategoryAttribute(string name) =>
            Name = name;

        /// <summary>
        /// Gets the hierarchical category name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Extracts categories from hierarchical category name and adds them to a test.
        /// </summary>
        /// <param name="test">The test to modify.</param>
        public void ApplyToTest(Test test)
        {
            Type thisType = GetType();
            HierarchicalCategorySettingsAttribute settings = HierarchicalCategoryResolver.ExtractHierarchicalCategorySettings(thisType);

            HierarchicalCategoryResolver resolver = new HierarchicalCategoryResolver
            {
                CategorySeparator = settings.CategorySeparator,
                WordSeparator = settings.WordSeparator
            };

            string[] categories = Name == null
                ? resolver.ExtractCategories(thisType)
                : resolver.ExtractCategories(Name);

            if (settings.ApplyEachLevelToTestProperties != null)
                test.Properties.AddCrossJoinedRange(settings.ApplyEachLevelToTestProperties, categories);

            if (settings.ApplyTopLevelToTestProperties != null)
                test.Properties.AddCrossJoinedRange(settings.ApplyTopLevelToTestProperties, categories.Reverse().Take(1));
        }
    }
}
