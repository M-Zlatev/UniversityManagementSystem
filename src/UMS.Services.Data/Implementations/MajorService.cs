namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using UMS.Data;
    using UMS.Data.Models;

    public class MajorService : IMajorService
    {
        private const int MajorPageSize = 10;

        private readonly UmsDbContext data;

        public MajorService(UmsDbContext data)
            => this.data = data;

        public async Task<IEnumerable<MajorListingServiceModel>> All(int page)
            => await this.data
                .Majors
                .Skip((page - 1) * MajorPageSize)
                .Take(MajorPageSize)
                .Select(m => new MajorListingServiceModel
                {
                    Id = m.Id,
                    MajorName = m.Name,
                    Description = m.Description,
                    BelongsToDepartment = m.Department.Name,
                })
                .ToListAsync();
    }
}
