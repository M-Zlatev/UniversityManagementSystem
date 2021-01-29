namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Faculties;
    using UMS.Data.Models;

    public interface IFacultyService
    {
        public Task<IEnumerable<FacultyListingServiceModel>> All(int page);

        public Task<FacultyDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, string streetName, string townName, string countryName, string email, string phoneNumber, string fax, string userId);

        Task<bool> Edit(int id, string name, string description, string streetName, string townName, string countryName, string email, string phoneNumber, string fax);

        Task<bool> Delete(int id);
    }
}
