namespace NUnitExtras.HierarchicalCategories.Tests;

public class HierarchicalCategorySettingsAttributeTests : BaseFixture
{
    [Test]
    [HybridCategory.Level1.Level1_1]
    public void HierarchicalCategorySettingsAttribute_ApplyTopLevelsToTestProperties_One() =>
        TestProperties[HybridCategory.TopLevelPropertyName].Should().Equal(
            "Level 1.Level 1 1");

    [Test]
    [HybridCategory.Level1.Level1_1]
    [HybridCategory.Level1.Level1_2]
    public void HierarchicalCategorySettingsAttribute_ApplyTopLevelsToTestProperties_Two() =>
        TestProperties[HybridCategory.TopLevelPropertyName].Should().Equal(
            "Level 1.Level 1 1",
            "Level 1.Level 1 2");

    [Test]
    [HybridCategory.Level1.Level1_1]
    public void HierarchicalCategorySettingsAttribute_ApplyAllLevelsToTestProperties_One()
    {
        string[] expectedValues =
        [
            "Level 1",
            "Level 1.Level 1 1"
        ];

        TestProperties[HybridCategory.EachLevelPropertyName].Should().Equal(expectedValues);
        TestProperties[PropertyNames.Category].Should().Equal(expectedValues);
    }

    [Test]
    [HybridCategory.Level1.Level1_1]
    [HybridCategory.Level1.Level1_2]
    public void HierarchicalCategorySettingsAttribute_ApplyAllLevelsToTestProperties_Two()
    {
        string[] expectedValues =
        [
            "Level 1",
            "Level 1.Level 1 1",
            "Level 1.Level 1 2"
        ];

        TestProperties[HybridCategory.EachLevelPropertyName].Should().Equal(expectedValues);
        TestProperties[PropertyNames.Category].Should().Equal(expectedValues);
    }

    [Test]
    [CategoryWithSlashSeparator.Child1.SubChild1]
    [CategoryWithSlashSeparator.Child2]
    public void HierarchicalCategorySettingsAttribute_CategorySeparator_Slash() =>
        TestProperties.Categories.Should().Equal(
            "Category With Slash Separator",
            "Category With Slash Separator/Child 1",
            "Category With Slash Separator/Child 1/Sub-child 1",
            "Category With Slash Separator/Child 2");

    [Test]
    [CategoryWithNullWordSeparator.Child1.SubChild1]
    [CategoryWithNullWordSeparator.Child2]
    public void HierarchicalCategorySettingsAttribute_WordSeparator_Null() =>
        TestProperties.Categories.Should().Equal(
            "CategoryWithNullWordSeparator",
            "CategoryWithNullWordSeparator.Child1",
            "CategoryWithNullWordSeparator.Child1.Sub-child 1",
            "CategoryWithNullWordSeparator.Child2");

    [Test]
    [CategoryWithDashWordSeparator.Child1.SubChild1]
    [CategoryWithDashWordSeparator.Child2]
    public void HierarchicalCategorySettingsAttribute_WordSeparator_Dash() =>
        TestProperties.Categories.Should().Equal(
            "Category-With-Dash-Word-Separator",
            "Category-With-Dash-Word-Separator.Child-1",
            "Category-With-Dash-Word-Separator.Child-1.Sub-child 1",
            "Category-With-Dash-Word-Separator.Child-2");
}
