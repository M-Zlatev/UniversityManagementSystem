namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;
    using UMS.Services.Data.Models.HomeworksParametersModels;
    using ServicesLifetimeContracts;

    public interface IHomeworksService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int homeworksPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(HomeworkCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, HomeworkEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
