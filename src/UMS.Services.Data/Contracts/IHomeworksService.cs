namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Web.ViewModels.Homeworks;

    public interface IHomeworksService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int homeworksPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CreateHomeworkInputForm createForm);

        Task<bool> EditAsync(int id, EditHomeworkInputForm editForm);

        Task<bool> DeleteAsync(int id);
    }
}
