namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Common;
    using UMS.Data.Common.Enumerations;

    public interface IMajorService : ITransientService
    {
        public Task<IEnumerable<IListModel>> All(int page);

        public Task<IListModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, MajorType majorType, double duration, string belongsToDepartment, string userId);

        Task<bool> Edit(int id, string name, string description, MajorType majorType, double duration, string belongsToDepartment);

        Task<bool> Delete(int id);
    }
}
