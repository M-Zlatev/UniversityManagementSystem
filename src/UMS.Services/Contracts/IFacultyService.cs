namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IFacultyService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage);

        //public Task<FacultyDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, string streetName, string townName, string countryName, string email, string phoneNumber, string fax, string userId);

        Task<bool> Edit(int id, string name, string description, string streetName, string townName, string countryName, string email, string phoneNumber, string fax);

        Task<bool> Delete(int id);
    }
}
