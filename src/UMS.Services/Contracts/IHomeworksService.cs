namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.HomeworksParametersModels;
    using ServicesLifetimeContracts;
    using UMS.Data.Common.Enumerations;

    public interface IHomeworksService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int homeworksPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(HomeworkCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, HomeworkEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
