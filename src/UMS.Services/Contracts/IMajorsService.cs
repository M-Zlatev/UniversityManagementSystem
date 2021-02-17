namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models.MajorsParametersModels;
    using UMS.Data.Common.Enumerations;

    public interface IMajorsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage);

        public T GetDetailsById<T>(int id);

        Task<bool> Exists(int id);

        int GetCount();

        Task<int> Create(MajorCreateParametersModel createParametersModel);

        Task<bool> Edit(int id, MajorEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
