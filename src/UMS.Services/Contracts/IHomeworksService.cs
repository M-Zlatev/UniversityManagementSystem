namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;

    public interface IHomeworksService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int homeworksPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(string content, HomeworkType homeworkType, DateTime assignmentTime, DateTime openForSubmissionTime, string doneByStudent);

        Task<bool> Edit(int id, string content, HomeworkType homeworkType, DateTime assignmentTime, DateTime openForSubmissionTime);

        Task<bool> Delete(int id);
    }
}
