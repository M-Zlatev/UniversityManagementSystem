namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Web.ViewModels.Departments;

    public interface IDepartmentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int departmentsPerPage);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CreateDepartmentInputForm createForm);

        Task<bool> EditAsync(int id, EditDepartmentInputForm editForm);

        Task<bool> DeleteAsync(int id);
    }
}
