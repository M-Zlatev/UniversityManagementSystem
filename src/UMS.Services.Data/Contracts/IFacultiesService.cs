namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using Web.ViewModels.Faculties;

    public interface IFacultiesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CreateFacultyInputForm createForm);

        Task<bool> EditAsync(int id, EditFacultyInputForm editForm);

        Task<bool> DeleteAsync(int id);
    }
}
