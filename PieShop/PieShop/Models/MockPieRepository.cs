using System;
using System.Collections.Generic;
using System.Linq;

namespace PieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository categoryRepository = new MockCategoryRepository();

        private Category FruitPieCategory =>
            categoryRepository.Categories.First(c => c.Name.Equals("Fruit pies"));

        private Category CheesecakeCategory =>
            categoryRepository.Categories.First(c => c.Name.Equals("Cheesecakes"));

        private Category SeasonalPieCategory =>
            categoryRepository.Categories.First(c => c.Name.Equals("Seasonal pies"));

        public IEnumerable<Pie> Pies =>
            new List<Pie>
            {
                new Pie { Id = 1, Name = "Strawberry Pie", Price = 12.55M, ShortDescription = "A pie", LongDescription = "A pie made of fresh, local ingredients", AllergyInformation = "Ask the cashier for allergy information.", IsPieOfTheWeek = false, InStock = true, ImageUrl = "https://www.google.com", ImageThumbnailUrl = "https://www.google.com", Category = FruitPieCategory, CategoryId = FruitPieCategory.Id },
                new Pie { Id = 1, Name = "Starwberry Cheesecake", Price = 12.55M, ShortDescription = "A pie", LongDescription = "A pie made of fresh, local ingredients", AllergyInformation = "Ask the cashier for allergy information.", IsPieOfTheWeek = true, InStock = true, ImageUrl = "https://www.google.com", ImageThumbnailUrl = "https://www.google.com", Category = CheesecakeCategory, CategoryId = CheesecakeCategory.Id },
                new Pie { Id = 1, Name = "Rhubarb Pie", Price = 12.55M, ShortDescription = "A pie", LongDescription = "A pie made of fresh, local ingredients", AllergyInformation = "Ask the cashier for allergy information.", IsPieOfTheWeek = true, InStock = true, ImageUrl = "https://www.google.com", ImageThumbnailUrl = "https://www.google.com", Category = FruitPieCategory, CategoryId = FruitPieCategory.Id },
                new Pie { Id = 1, Name = "Pumpkin Pie", Price = 12.55M, ShortDescription = "A pie", LongDescription = "A pie made of fresh, local ingredients", AllergyInformation = "Ask the cashier for allergy information.", IsPieOfTheWeek = false, InStock = true, ImageUrl = "https://www.google.com", ImageThumbnailUrl = "https://www.google.com", Category = SeasonalPieCategory, CategoryId = SeasonalPieCategory.Id }
            };

        public IEnumerable<Pie> PiesOfTheWeek =>
            Pies.Where(p => p.IsPieOfTheWeek);

        public Pie GetPieById(int id) =>
            Pies.FirstOrDefault(p => p.Id.Equals(id));
    }
}
