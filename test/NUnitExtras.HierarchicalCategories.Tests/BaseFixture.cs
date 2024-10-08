﻿namespace NUnitExtras.HierarchicalCategories.Tests;

[TestFixture]
public abstract class BaseFixture
{
    protected TestPropertiesAdapter TestProperties { get; } = new TestPropertiesAdapter();

    protected FixturePropertiesAdapter FixtureProperties { get; } = new FixturePropertiesAdapter();

    public class TestPropertiesAdapter
    {
        public IReadOnlyList<string> Categories =>
            this[PropertyNames.Category];

        public IReadOnlyList<string> this[string propertyName] =>
            TestContext.CurrentContext.Test.Properties[propertyName].ToStringArray();
    }

    public class FixturePropertiesAdapter
    {
        public IReadOnlyList<string> Categories =>
            this[PropertyNames.Category];

        public IReadOnlyList<string> this[string propertyName] =>
            ResolveFixture(TestExecutionContext.CurrentContext.CurrentTest).Properties[propertyName].ToStringArray();

        private static TestFixture ResolveFixture(ITest test) =>
            test as TestFixture ?? ResolveFixture(test.Parent);
    }
}
