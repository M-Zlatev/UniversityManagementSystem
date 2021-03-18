namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;
    using UMS.Services.Data.Models.ResourcesParametersModels;

    public interface IResourcesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int resourcesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(ResourceCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, ResourceEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
