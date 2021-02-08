namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Data.Models.FacultiesParametersModels;

    public interface IFacultiesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(FacultyCreateParametersModel createParametersModel);

        Task<bool> Edit(FacultyEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
