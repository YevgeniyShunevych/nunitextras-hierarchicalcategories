using NUnit.Extras;

namespace NUnitExtras.HierarchicalCategories.Tests
{
    public static class Module
    {
        public class UI : HierarchicalCategoryAttribute
        {
            public class Authentication : HierarchicalCategoryAttribute
            {
                public class Admin : HierarchicalCategoryAttribute
                {
                }

                public class Guest : HierarchicalCategoryAttribute
                {
                }
            }

            public class Products : HierarchicalCategoryAttribute
            {
                public class Purchase : HierarchicalCategoryAttribute
                {
                }

                public class Editing : HierarchicalCategoryAttribute
                {
                }
            }
        }

        [HierarchicalCategoryName("API")]
        public class Api : HierarchicalCategoryAttribute
        {
            public class Authentication : HierarchicalCategoryAttribute
            {
                public class Admin : HierarchicalCategoryAttribute
                {
                }

                public class Guest : HierarchicalCategoryAttribute
                {
                }
            }
        }
    }
}
