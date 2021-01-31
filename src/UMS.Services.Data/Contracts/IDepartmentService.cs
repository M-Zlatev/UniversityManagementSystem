namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Models;
    using UMS.Common;

    public interface IDepartmentService : ITransientService
    {
        public Task<IEnumerable<IListModel>> All(int page);

        public Task<IListModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, string email, string phoneNumber, string fax, string belongsToFaculty, string userId);

        Task<bool> Edit(int id, string name, string description, string email, string phoneNumber, string fax);

        Task<bool> Delete(int id);
    }
}
