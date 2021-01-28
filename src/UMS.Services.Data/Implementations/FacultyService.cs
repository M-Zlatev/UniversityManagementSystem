namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using UMS.Data;
    using UMS.Data.Models;

    public class FacultyService : IFacultyService
    {
        private const int FacultyPageSize = 10;

        private readonly UmsDbContext data;

        public FacultyService(UmsDbContext data)
            => this.data = data;

        public async Task<IEnumerable<FacultyListingServiceModel>> All(int page)
            => await this.data
                .Faculties
                .Skip((page - 1) * FacultyPageSize)
                .Take(FacultyPageSize)
                .Select(f => new FacultyListingServiceModel
                {
                    Id = f.Id,
                    FacultyName = f.Name,
                    Description = f.Description,
                })
                .ToListAsync();
    }
}
