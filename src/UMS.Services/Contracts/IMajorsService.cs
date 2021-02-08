namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;
    using UMS.Services.Data.Models.MajorsParametersModels;

    public interface IMajorsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(MajorCreateParametersModel createParametersModel);

        Task<bool> Edit(MajorEditParametersModel editParametersModel);

        Task<bool> Delete(int id);
    }
}
