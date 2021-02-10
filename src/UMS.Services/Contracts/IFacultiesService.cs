namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Data.Models.FacultiesParametersModels;

    public interface IFacultiesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(FacultyCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, FacultyEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
