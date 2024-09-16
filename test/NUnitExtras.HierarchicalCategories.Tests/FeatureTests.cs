namespace NUnitExtras.HierarchicalCategories.Tests;

public class FeatureTests : BaseFixture
{
    [Test]
    [Feature.Analytics]
    public void Analytics_Test() =>
        TestProperties.Categories.Should().Equal("Analytics");

    [Test]
    [Feature.Analytics.AssistedReview]
    public void Analytics_AssistedReview_Test() =>
        TestProperties.Categories.Should().Equal(
            "Analytics",
            "Analytics.Assisted Review");

    [Test]
    [Feature.Analytics.Infrastructure.Agents]
    public void Analytics_Infrastructure_Agents_Test() =>
        TestProperties.Categories.Should().Equal(
            "Analytics",
            "Analytics.Infrastructure",
            "Analytics.Infrastructure.Agents");

    [Test]
    [Feature.Analytics.Infrastructure.Servers]
    public void Analytics_Infrastructure_Servers_Test() =>
        TestProperties.Categories.Should().Equal(
            "Analytics",
            "Analytics.Infrastructure",
            "Analytics.Infrastructure.Servers");

    [Test]
    [Feature.Analytics.Infrastructure.Servers.AnalyticsIndexing]
    public void Analytics_Infrastructure_Servers_AnalyticsIndexing_Test() =>
        TestProperties.Categories.Should().Equal(
            "Analytics",
            "Analytics.Infrastructure",
            "Analytics.Infrastructure.Servers",
            "Analytics.Infrastructure.Servers.Analytics Indexing");

    [Test]
    [Feature.Analytics.Infrastructure.Servers.StructuredData]
    public void Analytics_Infrastructure_Servers_StructuredData_Test() =>
        TestProperties.Categories.Should().Equal(
            "Analytics",
            "Analytics.Infrastructure",
            "Analytics.Infrastructure.Servers",
            "Analytics.Infrastructure.Servers.Structured Data");
}
