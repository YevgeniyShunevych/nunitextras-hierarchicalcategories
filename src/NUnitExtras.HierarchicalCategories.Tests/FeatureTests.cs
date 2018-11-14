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
        public void Feature_Analytics()
        {
            TestCategories.Should().BeEquivalentTo("Analytics");
        }

        [Test]
        [Feature.Analytics.AssistedReview]
        public void Feature_Analytics_AssistedReview()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Assisted Review");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Agents]
        public void Feature_Analytics_Infrastructure_Agents()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Agents");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Servers]
        public void Feature_Analytics_Infrastructure_Servers()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Servers");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Servers.AnalyticsIndexing]
        public void Feature_Analytics_Infrastructure_Servers_AnalyticsIndexing()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Servers",
                "Analytics.Infrastructure.Servers.Analytics Indexing");
        }

        [Test]
        [Feature.Analytics.Infrastructure.Servers.StructuredData]
        public void Feature_Analytics_Infrastructure_Servers_StructuredData()
        {
            TestCategories.Should().BeEquivalentTo(
                "Analytics",
                "Analytics.Infrastructure",
                "Analytics.Infrastructure.Servers",
                "Analytics.Infrastructure.Servers.Structured Data");
        }
    }
}
