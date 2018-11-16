# NUnitExtras.HierarchicalCategories

Provides a functionality for hierarchical categorization of NUnit tests with the following way:

```cs
[Test]
[Module.ParentModule.SubModule.SomeFeature]
public void SomeTest()
{
}
```

And the test will get all 3 categories for each module level:

- `"Parent Module"`
- `"Parent Module.Sub Module"`
- `"Parent Module.Sub Module.Some Feature"`

It will give you ability to filter NUnit tests using any complex category filters in build pipelines or wherever.

Above sample is equal to the following vanilla NUnit sample:

```cs
[Test]
[Category("Parent Module")]
[Category("Parent Module.Sub Module")]
[Category("Parent Module.Sub Module.Some Feature")]
public void SomeTest()
{
}
```

## Usage

### Modules Definition Class

Define class which contains nested hierarchy of class attributes for modules:

```cs
using NUnit.Extras;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    public static class Feature
    {
        public class Analytics : HierarchicalCategoryAttribute
        {
            public class AssistedReview : HierarchicalCategoryAttribute
            {
            }

            public class Infrastructure : HierarchicalCategoryAttribute
            {
                public class Agents : HierarchicalCategoryAttribute
                {
                }

                public class Servers : HierarchicalCategoryAttribute
                {
                    public class AnalyticsIndexing : HierarchicalCategoryAttribute
                    {
                    }

                    public class StructuredData : HierarchicalCategoryAttribute
                    {
                    }
                }
            }
        }
    }
}
```

All module attributes should inherit `HierarchicalCategoryAttribute`.

### Use in Tests

Mark the tests with corresponding attributes:

```cs
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
```

#### Tests Grouped by Outcome

![Tests Explorer - Grouped by Outcome](images/test-explorer-groupd-by-outcome.png)

#### Tests Grouped by Traits

![Tests Explorer - Grouped by Traits](images/test-explorer-groupd-by-traits.png)

### Apply to Fixture

You can also apply attributes to fixtures.
This will apply the category traites to all child tests.

```cs
[TestFixture]
[Module.UI.Authentication]
public class SomeTests
{
    // Tests...
}
```

### Multiple Categories

It also possible to apply multiple hierarchical categories to tests, fixtures and assemblies.

```cs
[Test]
[Module.UI.Authentication.Admin]
[Module.UI.Products.Editing]
public void SomeTest()
{
}
```

### Special Naming

To set specific module name that contains special characters that are not allowed in class naming or for name override use `HierarchicalCategoryNameAttribute`:

```cs
[HierarchicalCategoryName("Installation & Deployment")]
public class InstallationAndDeployment : HierarchicalCategoryAttribute
{
}
```

## License

`NUnitExtras.HierarchicalCategories` is an open source software, licensed under the Apache License 2.0.
See [LICENSE](LICENSE) for details.