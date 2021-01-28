namespace UMS.Services.Data.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using UMS.Data.Models;

    public interface IMajorService
    {
        public Task<IEnumerable<MajorListingServiceModel>> All(int page);
    }
}
