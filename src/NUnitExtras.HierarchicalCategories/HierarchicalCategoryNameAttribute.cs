using System;

namespace NUnit.Extras
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class HierarchicalCategoryNameAttribute : Attribute
    {
        public HierarchicalCategoryNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
