namespace UMS.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Data.Models;

    public interface IDepartmentsService : ITransientService
    {
        public IEnumerable<T> GetAll<T>(int page, int departmentsPerPage);

        public T GetDetails<T>(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, string email, string phoneNumber, string fax, string belongsToFaculty, string userId);

        Task<bool> Edit(int id, string name, string description, string email, string phoneNumber, string fax);

        Task<bool> Delete(int id);
    }
}
