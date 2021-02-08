namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Data.Models.CoursesParametersModels;

    public interface ICoursesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int coursesPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(CourseCreateParametersModel createParametersModel);

        Task<bool> Edit(CourseEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
