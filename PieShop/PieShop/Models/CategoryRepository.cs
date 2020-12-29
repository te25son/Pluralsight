using System.Collections.Generic;

namespace PieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext context;

        public CategoryRepository(AppDbContext appDbContext)
        {
            context = appDbContext;
        }

        public IEnumerable<Category> Categories => context.Categories;
    }
}
