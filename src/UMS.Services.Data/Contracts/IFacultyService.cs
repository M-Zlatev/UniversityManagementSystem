namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Models;

    public interface IFacultyService
    {
        public Task<IEnumerable<FacultyListingServiceModel>> All(int page);
    }
}
