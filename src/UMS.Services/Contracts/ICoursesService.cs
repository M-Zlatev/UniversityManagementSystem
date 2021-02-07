namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICoursesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int coursesPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, DateTime startDate, DateTime endDate, decimal price, string belongsToMajor, string userId);

        Task<bool> Edit(int id, string name, string description, DateTime startDate, DateTime endDate, decimal price, string belongsToMajor);

        Task<bool> Delete(int id);
    }
}
