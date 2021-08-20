namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;

    using Services.Contracts.ServicesLifetimeContracts;

    public interface ICategoriesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int categoriesPerPage);

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        T GetByName<T>(string name);

        int GetCount();
    }
}
