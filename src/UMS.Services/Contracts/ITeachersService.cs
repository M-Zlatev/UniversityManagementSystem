namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Common.Enumerations;

    public interface ITeachersService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int teachersPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string firstName, string middleName, string lastName, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string phoneNumber, string email, string imageUrl, string userId);

        Task<bool> Edit(int id, string firstName, string middleName, string lastName, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string phoneNumber, string email, string imageUrl);

        Task<bool> Delete(int id);
    }
}
