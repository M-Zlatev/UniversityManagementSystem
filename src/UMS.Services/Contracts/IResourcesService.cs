namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;

    public interface IResourcesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int resourcesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(string name, ResourceType resourceType, string url, string belongToCourse);

        Task<bool> Edit(int id, string name, ResourceType resourceType, string url, string belongToCourse);

        Task<bool> Delete(int id);
    }
}
