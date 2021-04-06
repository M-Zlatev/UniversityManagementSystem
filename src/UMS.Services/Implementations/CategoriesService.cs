namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Mapping.Infrastructure;
    using UMS.Data.Models.Forum;
    using UMS.Data.Repositories.Contracts;

    public class CategoriesService : ICategoriesService
    {
        private const int CategoryPageSize = 10;

        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
            => this.categoriesRepository = categoriesRepository;

        public IEnumerable<T> GetAll<T>(int page, int categoriesPerPage = CategoryPageSize)
            => this.categoriesRepository.AllAsNoTracking()
             .OrderBy(c => c.Id)
             .Skip((page - 1) * categoriesPerPage)
             .Take(categoriesPerPage)
             .To<T>()
             .ToList();

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
            => this.categoriesRepository.AllAsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        public T GetByName<T>(string name)
            => this.categoriesRepository.All()
                .Where(x => x.Name.Replace(" ", "-") == name.Replace(" ", "-"))
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.categoriesRepository.All().Count();
    }
}
