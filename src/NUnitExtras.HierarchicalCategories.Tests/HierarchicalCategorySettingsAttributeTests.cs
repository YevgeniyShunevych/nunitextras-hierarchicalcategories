using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    public class HierarchicalCategorySettingsAttributeTests : BaseFixture
    {
        [Test]
        [HybridCategory.Level1.Level1_1]
        public void HierarchicalCategorySettingsAttribute_ApplyTopLevelsToTestProperties_One()
        {
            TestProperties[HybridCategory.TopLevelPropertyName].Should().Equal(
                "Level 1.Level 1 1");
        }

        [Test]
        [HybridCategory.Level1.Level1_1]
        [HybridCategory.Level1.Level1_2]
        public void HierarchicalCategorySettingsAttribute_ApplyTopLevelsToTestProperties_Two()
        {
            TestProperties[HybridCategory.TopLevelPropertyName].Should().Equal(
                "Level 1.Level 1 1",
                "Level 1.Level 1 2");
        }

        [Test]
        [HybridCategory.Level1.Level1_1]
        public void HierarchicalCategorySettingsAttribute_ApplyAllLevelsToTestProperties_One()
        {
            string[] expectedValues =
            {
                "Level 1",
                "Level 1.Level 1 1"
            };

            TestProperties[HybridCategory.AllLevelsPropertyName].Should().Equal(expectedValues);
            TestProperties[PropertyNames.Category].Should().Equal(expectedValues);
        }

        [Test]
        [HybridCategory.Level1.Level1_1]
        [HybridCategory.Level1.Level1_2]
        public void HierarchicalCategorySettingsAttribute_ApplyAllLevelsToTestProperties_Two()
        {
            string[] expectedValues =
            {
                "Level 1",
                "Level 1.Level 1 1",
                "Level 1.Level 1 2"
            };

            TestProperties[HybridCategory.AllLevelsPropertyName].Should().Equal(expectedValues);
            TestProperties[PropertyNames.Category].Should().Equal(expectedValues);
        }
    }
}
