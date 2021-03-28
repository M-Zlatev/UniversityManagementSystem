namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.DepartmentsParametersModels;
    using ServicesLifetimeContracts;
    using UMS.Data.Models;

    public interface IDepartmentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int departmentsPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(DepartmentCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, DepartmentEditParametersModel editParametersModel);

        Task<bool> Delete(int id);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
