using System;
using NUnit.Framework.Internal;

namespace NUnit.Extras
{
    /// <summary>
    /// Specifies settings for hierarchical category name building and applying as NUnit property.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HierarchicalCategorySettingsAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the category separator.
        /// The default value is <c>"."</c>.
        /// </summary>
        public string CategorySeparator { get; set; } = HierarchicalCategoryResolver.DefaultCategorySeparator;

        /// <summary>
        /// Gets or sets the category word separator.
        /// The default value is <c>" "</c>.
        /// </summary>
        public string WordSeparator { get; set; } = HierarchicalCategoryResolver.DefaultWordSeparator;

        /// <summary>
        /// Gets or sets the names of the test properties to apply each hierarchical level (such as "lvl1", "lvl1.1" and "lvl1.1.1") to.
        /// By default contains <see cref="PropertyNames.Category"/> (<c>"Category"</c>).
        /// </summary>
        public string[] ApplyEachLevelToTestProperties { get; set; } = new[] { PropertyNames.Category };

        /// <summary>
        /// Gets or sets the names of the test properties to apply only top hierarchical level (such as "lvl1.1.1") to.
        /// By default is empty.
        /// </summary>
        public string[] ApplyTopLevelToTestProperties { get; set; } = new string[0];
    }
}
