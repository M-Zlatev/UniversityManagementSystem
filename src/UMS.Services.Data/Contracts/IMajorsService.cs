namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Web.ViewModels.Majors;

    public interface IMajorsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(CreateMajorInputForm createForm);

        Task<bool> EditAsync(int id, EditMajorInputForm editForm);

        Task<bool> DeleteAsync(int id);
    }
}
