namespace UMS.Services.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Data.Common.Enumerations;
    using UMS.Web.ViewModels.Resources;

    public interface IResourcesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int resourcesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CreateResourceInputForm createForm);

        Task<bool> EditAsync(int id, EditResourceInputForm editForm);

        Task<bool> DeleteAsync(int id);
    }
}
