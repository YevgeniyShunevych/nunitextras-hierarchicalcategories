using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    [TestFixture]
    public class FeatureTests
    {
        protected static string[] TestCategories =>
            TestContext.CurrentContext.Test.Properties[PropertyNames.Category].Cast<string>().ToArray();

        [Test]
        [Feature.Analytics]
        public void Analytics_Test()
        {
            TestCategories.Should().BeEquivalentTo("Analytics");
        }

        [Test]
        [Feature.Analytics.AssistedReview]
        public void Analytics_AssistedReview_Test()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Assisted Review");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Agents]
        public void Analytics_Infrastructure_Agents_Test()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Agents");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Servers]
        public void Analytics_Infrastructure_Servers_Test()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Servers");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Servers.AnalyticsIndexing]
        public void Analytics_Infrastructure_Servers_AnalyticsIndexing_Test()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Servers",
                "Analytics.Infrastructure.Servers.Analytics Indexing");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Servers.StructuredData]
        public void Analytics_Infrastructure_Servers_StructuredData_Test()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Servers",
                "Analytics.Infrastructure.Servers.Structured Data");
        }
    }
}
