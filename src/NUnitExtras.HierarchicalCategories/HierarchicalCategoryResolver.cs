using System;
using System.Linq;

namespace NUnit.Extras
{
    /// <summary>
    /// Contains functionality to extract hierarchical catregory names.
    /// </summary>
    public static class HierarchicalCategoryResolver
    {
        public const string CategorySeparator = ".";

        public const string WordSeparator = " ";

        /// <summary>
        /// Extracts the categories.
        /// </summary>
        /// <param name="hierarchicalCategoryName">Name of the hierarchical category.</param>
        /// <returns>An array of categories.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="hierarchicalCategoryName"/> is <see langword="null"/>.</exception>
        public static string[] ExtractCategories(string hierarchicalCategoryName)
        {
            if (hierarchicalCategoryName == null)
                throw new ArgumentNullException(nameof(hierarchicalCategoryName));

            string[] parts = hierarchicalCategoryName.Split(new[] { CategorySeparator }, StringSplitOptions.RemoveEmptyEntries).
                Select(x => x.Trim()).
                ToArray();

            return parts.Select((x, i) => string.Join(CategorySeparator, parts.Take(i + 1))).ToArray();
        }

        /// <summary>
        /// Extracts the categories.
        /// </summary>
        /// <param name="type">The type inherited from <see cref="HierarchicalCategoryAttribute"/>.</param>
        /// <returns>An array of categories.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
        public static string[] ExtractCategories(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            if (!IsHierarchicalCategoryAttribute(type))
                return new string[0];

            string hierarchicalCategoryName = ExtractHierarchicalCategoryFromType(type);
            return ExtractCategories(hierarchicalCategoryName);
        }

        public static string ExtractHierarchicalCategoryFromType(Type type)
        {
            string leadingCategory = null;

            if (type.DeclaringType != null && IsHierarchicalCategoryAttribute(type.DeclaringType))
                leadingCategory = ExtractHierarchicalCategoryFromType(type.DeclaringType);

            string name = ResolveNameFromType(type);

            return leadingCategory != null
                ? $"{leadingCategory}{CategorySeparator}{name}"
                : name;
        }

        private static bool IsHierarchicalCategoryAttribute(Type type)
        {
            return typeof(HierarchicalCategoryAttribute).IsAssignableFrom(type);
        }

        private static string ResolveNameFromType(Type type)
        {
            return type.GetAttribute<HierarchicalCategoryNameAttribute>()?.Name
                ?? ResolveNameFromTypeName(type.Name);
        }

        private static string ResolveNameFromTypeName(string typeName)
        {
            string name = typeName.EndsWith(nameof(Attribute))
                ? typeName.Substring(0, typeName.Length - nameof(Attribute).Length)
                : typeName;

            return string.Join(WordSeparator, name.SplitIntoWords());
        }

        /// <summary>
        /// Extracts the hierarchical category settings.
        /// Finds <see cref="HierarchicalCategorySettingsAttribute"/> in all ascendant types starting from <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of an attribute.</param>
        /// <returns>The found instance of <see cref="HierarchicalCategorySettingsAttribute"/> or default if not found.</returns>
        public static HierarchicalCategorySettingsAttribute ExtractHierarchicalCategorySettings(Type type)
        {
            if (type.TryGetAttribute(out HierarchicalCategorySettingsAttribute settingsAttribute))
                return settingsAttribute;
            else if (type.DeclaringType != null)
                return ExtractHierarchicalCategorySettings(type.DeclaringType);
            else
                return new HierarchicalCategorySettingsAttribute();
        }
    }
}
