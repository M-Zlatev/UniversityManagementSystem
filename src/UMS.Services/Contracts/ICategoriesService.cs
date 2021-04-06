namespace UMS.Services.Contracts
{
    using System.Collections.Generic;

    using ServicesLifetimeContracts;

    public interface ICategoriesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int categoriesPerPage);

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        T GetByName<T>(string name);

        int GetCount();
    }
}
