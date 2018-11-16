using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    [TestFixture]
    [Module.UI.Authentication.Admin]
    [Module.UI.Products.Editing]
    public class MultipleAttributesAtFixtureTests
    {
        protected static string[] TestCategories =>
            TestContext.CurrentContext.Test.Properties[PropertyNames.Category].Cast<string>().ToArray();

        protected static string[] FixtureTestCategories { get; private set; }

        [OneTimeSetUp]
        public void GlobalSetUp()
        {
            // Currently in NUnit it is possible to get fixture attributes only during [OneTimeSetUp] method.
            FixtureTestCategories = TestCategories;
        }

        [Test]
        public void MultipleAttributesAtFixture_Test()
        {
            FixtureTestCategories.Should().BeEquivalentTo(
                "UI",
                "UI.Authentication",
                "UI.Authentication.Admin",
                "UI.Products",
                "UI.Products.Editing");
        }

        [Test]
        [Module.Api.Authentication.Admin]
        public void MultipleAttributesAtFixture_WithAttributeAtTest_Test()
        {
            FixtureTestCategories.Should().BeEquivalentTo(
                "UI",
                "UI.Authentication",
                "UI.Authentication.Admin",
                "UI.Products",
                "UI.Products.Editing");

            TestCategories.Should().BeEquivalentTo(
                "API",
                "API.Authentication",
                "API.Authentication.Admin");
        }
    }
}
