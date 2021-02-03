namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Common.Enumerations;

    public interface IMajorsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, MajorType majorType, double duration, string belongsToDepartment, string userId);

        Task<bool> Edit(int id, string name, string description, MajorType majorType, double duration, string belongsToDepartment);

        Task<bool> Delete(int id);
    }
}
