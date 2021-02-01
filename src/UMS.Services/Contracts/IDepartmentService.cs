namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models;
    using Data.Models.Departments;

    public interface IDepartmentService : ITransientService
    {
        public Task<IEnumerable<DepartmentListingServiceModel>> All(int page);

        public Task<DepartmentDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, string email, string phoneNumber, string fax, string belongsToFaculty, string userId);

        Task<bool> Edit(int id, string name, string description, string email, string phoneNumber, string fax);

        Task<bool> Delete(int id);
    }
}
