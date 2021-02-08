namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Data.Models.TeachersParametersModels;
    using UMS.Data.Common.Enumerations;

    public interface ITeachersService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int teachersPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(TeacherCreateParametersModel createParametersModel);

        Task<bool> Edit(TeacherEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
