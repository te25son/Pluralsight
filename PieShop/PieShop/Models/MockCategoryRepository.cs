using System.Collections.Generic;

namespace PieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> Categories =>
            new List<Category>
            {
                new Category { Id = 1, Name = "Fruit pies", Description = "Delicious fruit pies!" },
                new Category { Id = 2, Name = "Cheesecakes", Description = "Delicious cheesecakes!" },
                new Category { Id = 3, Name = "Seasonal pies", Description = "Delicious pies for the season!" }
            };
    }
}
