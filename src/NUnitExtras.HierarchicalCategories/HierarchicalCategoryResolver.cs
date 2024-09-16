namespace NUnit.Extras;

/// <summary>
/// Contains functionality to extract hierarchical category names.
/// </summary>
public class HierarchicalCategoryResolver
{
    /// <summary>
    /// The default category separator.
    /// </summary>
    public const string DefaultCategorySeparator = ".";

    /// <summary>
    /// The default category word separator.
    /// </summary>
    public const string DefaultWordSeparator = " ";

    /// <summary>
    /// Gets or sets the category separator.
    /// The default value is <c>"."</c>.
    /// </summary>
    public string CategorySeparator { get; set; } = DefaultCategorySeparator;

    /// <summary>
    /// Gets or sets the category word separator.
    /// The default value is <c>" "</c>.
    /// </summary>
    public string WordSeparator { get; set; } = DefaultWordSeparator;

    /// <summary>
    /// Extracts the categories.
    /// </summary>
    /// <param name="hierarchicalCategoryName">Name of the hierarchical category.</param>
    /// <returns>An array of categories.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="hierarchicalCategoryName"/> is <see langword="null"/>.</exception>
    public string[] ExtractCategories(string hierarchicalCategoryName)
    {
        if (hierarchicalCategoryName == null)
            throw new ArgumentNullException(nameof(hierarchicalCategoryName));

        string[] parts = hierarchicalCategoryName.Split(new[] { CategorySeparator }, StringSplitOptions.RemoveEmptyEntries).
            Select(x => x.Trim()).
            ToArray();

        return parts.Select((_, i) => string.Join(CategorySeparator, parts.Take(i + 1))).ToArray();
    }

    /// <summary>
    /// Extracts the categories.
    /// </summary>
    /// <param name="type">The type inherited from <see cref="HierarchicalCategoryAttribute"/>.</param>
    /// <returns>An array of categories.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="type"/> is <see langword="null"/>.</exception>
    public string[] ExtractCategories(Type type)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type));

        if (!IsHierarchicalCategoryAttribute(type))
            return [];

        string hierarchicalCategoryName = ExtractHierarchicalCategoryFromType(type);
        return ExtractCategories(hierarchicalCategoryName);
    }

    public string ExtractHierarchicalCategoryFromType(Type type)
    {
        string leadingCategory = null;

        if (type.DeclaringType != null && IsHierarchicalCategoryAttribute(type.DeclaringType))
            leadingCategory = ExtractHierarchicalCategoryFromType(type.DeclaringType);

        string name = ResolveNameFromType(type);

        return leadingCategory != null
            ? $"{leadingCategory}{CategorySeparator}{name}"
            : name;
    }

    private static bool IsHierarchicalCategoryAttribute(Type type) =>
        typeof(HierarchicalCategoryAttribute).IsAssignableFrom(type);

    private string ResolveNameFromType(Type type) =>
        type.GetAttribute<HierarchicalCategoryNameAttribute>()?.Name
            ?? ResolveNameFromTypeName(type.Name);

    private string ResolveNameFromTypeName(string typeName)
    {
        string name = typeName.EndsWith(nameof(Attribute), StringComparison.Ordinal)
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
