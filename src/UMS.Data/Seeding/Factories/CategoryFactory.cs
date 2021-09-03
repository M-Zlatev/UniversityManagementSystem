namespace UMS.Data.Seeding.Factories
{
    using System.Collections;
    using System.Collections.Generic;

    using Contracts;
    using static SeedingConstants.CategorySeedingConstants;

    public class CategoryFactory : IFactory
    {
        public ICollection CreateEntities()
        {
            var categories = new List<(string Name, string Description, string ImageUrl)>
            {
                (CreditAndDegree.Name, CreditAndDegree.Description, CreditAndDegree.ImageUrl),
                (Accommodation.Name, Accommodation.Description, Accommodation.ImageUrl),
                (General.Name, General.Description, General.ImageUrl),
                (News.Name, News.Description, News.ImageUrl),
                (Sport.Name, Sport.Description, Sport.ImageUrl),
                (Movies.Name, Movies.Description, Movies.ImageUrl),
                (Travel.Name, Travel.Description, Travel.ImageUrl),
                (HelpCenter.Name, HelpCenter.Description, HelpCenter.ImageUrl),
                (Support.Name, Support.Description, Support.ImageUrl),
            };

            return categories;
        }
    }
}
