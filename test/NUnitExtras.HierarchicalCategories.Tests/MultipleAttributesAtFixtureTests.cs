namespace NUnitExtras.HierarchicalCategories.Tests;

[Module.UI.Authentication.Admin]
[Module.UI.Products.Editing]
public class MultipleAttributesAtFixtureTests : BaseFixture
{
    [Test]
    public void MultipleAttributesAtFixture_Test() =>
        FixtureProperties.Categories.Should().Equal(
            "UI",
            "UI.Authentication",
            "UI.Authentication.Admin",
            "UI.Products",
            "UI.Products.Editing");

    [Test]
    [Module.Api.Authentication.Admin]
    public void MultipleAttributesAtFixture_WithAttributeAtTest_Test()
    {
        FixtureProperties.Categories.Should().Equal(
            "UI",
            "UI.Authentication",
            "UI.Authentication.Admin",
            "UI.Products",
            "UI.Products.Editing");

        TestProperties.Categories.Should().Equal(
            "API",
            "API.Authentication",
            "API.Authentication.Admin");
    }
}
