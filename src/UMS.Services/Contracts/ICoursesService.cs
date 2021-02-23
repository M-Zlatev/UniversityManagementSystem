namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.CoursesParametersModels;

    public interface ICoursesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int coursesPerPage);

        public T GetDetailsById<T>(int id);

        Task<int> CreateAsync(CourseCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, CourseEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);

        Task<bool> Exists(int id);

        int GetCount();

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();
    }
}
