using System;
using System.Linq;

namespace NUnit.Extras
{
    public static class HierarchicalCategoryResolver
    {
        public const string CategorySeparator = ".";

        public const string WordSeparator = " ";

        public static string[] ExtractCategories(string hierarchicalCategoryName)
        {
            if (hierarchicalCategoryName == null)
                throw new ArgumentNullException(nameof(hierarchicalCategoryName));

            string[] parts = hierarchicalCategoryName.Split(new[] { CategorySeparator }, StringSplitOptions.RemoveEmptyEntries).
                Select(x => x.Trim()).
                ToArray();

            return parts.Select((x, i) => string.Join(CategorySeparator, parts.Take(i + 1))).ToArray();
        }

        public static string[] ExtractCategories(Type type)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            string hierarchicalCategoryName = ExtractHierarchicalCategoryFromType(type);
            return ExtractCategories(hierarchicalCategoryName);
        }

        public static string ExtractHierarchicalCategoryFromType(Type type)
        {
            string leadingCategory = null;

            if (type.DeclaringType != null && typeof(HierarchicalCategoryAttribute).IsAssignableFrom(type.DeclaringType))
                leadingCategory = ExtractHierarchicalCategoryFromType(type.DeclaringType);

            string name = ResolveNameFromType(type);

            return leadingCategory != null
                ? $"{leadingCategory}{CategorySeparator}{name}"
                : name;
        }

        private static string ResolveNameFromType(Type type)
        {
            HierarchicalCategoryNameAttribute nameAttribute = type.
                GetCustomAttributes(typeof(HierarchicalCategoryNameAttribute), true).
                FirstOrDefault() as HierarchicalCategoryNameAttribute;

            return nameAttribute?.Name ?? ResolveNameFromTypeName(type.Name);
        }

        private static string ResolveNameFromTypeName(string typeName)
        {
            string name = typeName.EndsWith(nameof(Attribute))
                ? typeName.Substring(0, typeName.Length - nameof(Attribute).Length)
                : typeName;

            return string.Join(WordSeparator, name.SplitIntoWords());
        }
    }
}
