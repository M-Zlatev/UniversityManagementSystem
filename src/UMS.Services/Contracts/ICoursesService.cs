namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.CoursesParametersModels;
    using ServicesLifetimeContracts;

    public interface ICoursesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int coursesPerPage);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CourseCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, CourseEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
