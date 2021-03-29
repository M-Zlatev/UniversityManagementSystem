namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.TeachersParametersModels;
    using UMS.Data.Common.Enumerations;
    using ServicesLifetimeContracts;

    public interface ITeachersService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int teachersPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(TeacherCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, TeacherEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
