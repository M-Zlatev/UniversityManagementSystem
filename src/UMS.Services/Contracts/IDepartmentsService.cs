namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models;
    using Services.Data.Models.DepartmentsParametersModels;

    public interface IDepartmentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int departmentsPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(DepartmentCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, DepartmentEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
