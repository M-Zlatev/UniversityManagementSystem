namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.FacultiesParametersModels;
    using ServicesLifetimeContracts;

    public interface IFacultiesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(FacultyCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, FacultyEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
