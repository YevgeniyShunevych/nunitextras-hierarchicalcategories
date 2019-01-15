﻿using System;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnit.Extras
{
    /// <summary>
    /// Applies single or multiple hierarchical catregories to a test.
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

            if (settings.ApplyAllLevelsToTestProperties != null)
                test.Properties.AddCrossJoinedRange(settings.ApplyAllLevelsToTestProperties, categories);

            if (settings.ApplyTopLevelsToTestProperties != null)
                test.Properties.AddCrossJoinedRange(settings.ApplyTopLevelsToTestProperties, categories.Reverse().Take(1));
        }
    }
}
