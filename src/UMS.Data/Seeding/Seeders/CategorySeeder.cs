namespace UMS.Data.Seeding.Seeders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Contracts;
    using Models.Forum;
    using Factories;

    public class CategorySeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categoryFactory = new CategoryFactory();
            var categories = categoryFactory.CreateEntities();

            // necessary cast for data manipulation in the AddAsyncCategoriesInDb method below
            var categoriesAfterCast = (List<(string Name, string Description, string ImageUrl)>)categories;

            await AddAsyncCategoriesInDb(dbContext, categoriesAfterCast);
        }

        private static async Task AddAsyncCategoriesInDb(UmsDbContext dbContext, List<(string Name, string Description, string ImageUrl)> categoriesAfterCast)
        {
            foreach (var currentCategory in categoriesAfterCast)
            {
                var category = new Category()
                {
                    Name = currentCategory.Name,
                    Description = currentCategory.Description,
                    ImageUrl = currentCategory.ImageUrl,
                };

                await dbContext.Categories.AddAsync(category);
            }
        }
    }
}
