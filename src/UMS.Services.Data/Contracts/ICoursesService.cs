namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Web.ViewModels.Courses;

    public interface ICoursesService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int coursesPerPage);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CreateCourseInputForm createCourseInputForm);

        Task<bool> EditAsync(int id, EditCourseInputForm editCourseInputForm);

        Task<bool> DeleteAsync(int id);
    }
}
