namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using UMS.Data;
    using UMS.Data.Models;

    public class DepartmentService
    {
        private const int DepartmentPageSize = 10;

        private readonly UmsDbContext data;

        public DepartmentService(UmsDbContext data)
            => this.data = data;

        public async Task<IEnumerable<DepartmentListingServiceModel>> All(int page)
            => await this.data
                .Departments
                .Skip((page - 1) * DepartmentPageSize)
                .Take(DepartmentPageSize)
                .Select(d => new DepartmentListingServiceModel
                {
                    Id = d.Id,
                    DepartmentName = d.Description,
                    BelongsToFaculty = d.Faculty.Name,
                })
                .ToListAsync();
    }
}
