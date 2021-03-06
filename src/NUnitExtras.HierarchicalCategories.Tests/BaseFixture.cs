﻿using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    [TestFixture]
    public abstract class BaseFixture
    {
        protected TestPropertiesAdapter TestProperties { get; } = new TestPropertiesAdapter();

        protected FixturePropertiesAdapter FixtureProperties { get; } = new FixturePropertiesAdapter();

        public class TestPropertiesAdapter
        {
            public string[] Categories =>
                this[PropertyNames.Category];

#pragma warning disable CA1822
            public string[] this[string propertyName] =>
                TestContext.CurrentContext.Test.Properties[propertyName].ToStringArray();
#pragma warning restore CA1822
        }

        public class FixturePropertiesAdapter
        {
            public string[] Categories =>
                this[PropertyNames.Category];

            public string[] this[string propertyName] =>
                ResolveFixture(TestExecutionContext.CurrentContext.CurrentTest).Properties[propertyName].ToStringArray();

            private TestFixture ResolveFixture(ITest test)
            {
                return test as TestFixture ?? ResolveFixture(test.Parent);
            }
        }
    }
}
