namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Models;

    public interface IDepartmentService
    {
        public Task<IEnumerable<DepartmentListingServiceModel>> All(int page);
    }
}
