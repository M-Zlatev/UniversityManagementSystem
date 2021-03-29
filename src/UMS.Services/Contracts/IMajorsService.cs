namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.MajorsParametersModels;
    using ServicesLifetimeContracts;
    using UMS.Data.Common.Enumerations;

    public interface IMajorsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage);

        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> CreateAsync(MajorCreateParametersModel createParametersModel);

        Task<bool> EditAsync(int id, MajorEditParametersModel editParametersModel);

        Task<bool> DeleteAsync(int id);
    }
}
