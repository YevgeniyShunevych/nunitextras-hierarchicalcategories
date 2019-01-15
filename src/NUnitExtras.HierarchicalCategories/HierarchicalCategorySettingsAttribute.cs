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
        /// The default value is <c>"."</c>
        /// </summary>
        public string CategorySeparator { get; set; } = HierarchicalCategoryResolver.DefaultCategorySeparator;

        /// <summary>
        /// Gets or sets the category word separator.
        /// The default value is <c>" "</c>.
        /// </summary>
        public string WordSeparator { get; set; } = HierarchicalCategoryResolver.DefaultWordSeparator;

        /// <summary>
        /// Gets or sets the names of the test properties to apply all hierarchical levels to, e.g.: "lvl1", "lvl1.1", "lvl1.1.1".
        /// By default contains <see cref="PropertyNames.Category"/>.
        /// </summary>
        public string[] ApplyAllLevelsToTestProperties { get; set; } = new[] { PropertyNames.Category };

        /// <summary>
        /// Gets or sets the names of the test properties to apply only top hierarchical level to, e.g.: "lvl1.1.1".
        /// By default is empty.
        /// </summary>
        public string[] ApplyTopLevelsToTestProperties { get; set; } = new string[0];
    }
}
