namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.StudentsParametersModels;
    using ServicesLifetimeContracts;
    using UMS.Data.Common.Enumerations;

    public interface IStudentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int studentsPerPage);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(StudentCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, StudentEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
