using System;

namespace NUnit.Extras
{
    /// <summary>
    /// Specifies hierarchical catregory name to the attribute inherited from <see cref="HierarchicalCategoryAttribute"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HierarchicalCategoryNameAttribute : Attribute
    {
        public HierarchicalCategoryNameAttribute(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        public string Name { get; }
    }
}
