namespace UMS.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Common.Enumerations;

    public interface IStudentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int id, int studentsPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string firstName, string middleName, string lastName, int uniformCivilNumber, DateTime dateOfBirth, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string major, string phoneNumber, string email, string imageUrl, bool hasScholarship, string userId);

        Task<bool> Edit(int id, string firstName, string middleName, string lastName, int uniformCivilNumber, DateTime dateOfBirth, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string major, string phoneNumber, string email, string imageUrl, bool hasScholarship);

        Task<bool> Delete(int id);
    }
}
