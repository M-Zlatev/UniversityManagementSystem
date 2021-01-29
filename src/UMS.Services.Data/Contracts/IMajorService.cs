namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Models.Majors;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;

    public interface IMajorService
    {
        public Task<IEnumerable<MajorListingServiceModel>> All(int page);

        public Task<MajorDetailsServiceModel> Details(int id);

        Task<bool> Exists(int id);

        Task<int> Create(string name, string description, MajorType majorType, double duration, string belongsToDepartment, string userId);

        Task<bool> Edit(int id, string name, string description, MajorType majorType, double duration, string belongsToDepartment);

        Task<bool> Delete(int id);
    }
}
