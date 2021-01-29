namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Models.Majors;
    using UMS.Data;
    using UMS.Data.Models;
    using UMS.Data.Common.Enumerations;

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

        public async Task<MajorDetailsServiceModel> Details(int id)
            => await this.data.Majors
                .Where(m => m.Id == id)
                .Select(m => new MajorDetailsServiceModel
                {
                    Id = m.Id,
                    Name = m.Name,
                    Description = m.Description,
                    MajorType = m.MajorType,
                    Duration = m.Duration,
                    BelongsToDepartment = m.Department.Name,
                })
                .FirstOrDefaultAsync();

        public async Task<bool> Exists(int id)
            => await this.data.Majors.AnyAsync(m => m.Id == id);

        public async Task<int> Create(string name, string description, MajorType majorType, double duration, string belongsToDepartment, string userId)
        {
            var departmentId = this.data
                .Departments
                .Where(d => d.Name == belongsToDepartment)
                .Select(d => d.Id)
                .FirstOrDefault();

            var major = new Major
            {
                Name = name,
                Description = description,
                MajorType = majorType,
                Duration = duration,
                DepartmentId = departmentId,
            };

            this.data.Add(major);

            await this.data.SaveChangesAsync();

            return major.Id;
        }

        public async Task<bool> Edit(int id, string name, string description, MajorType majorType, double duration, string belongsToDepartment)
        {
            var major = await this.data.Majors.FindAsync(id);

            if (major == null)
            {
                return false;
            }

            var departmentId = this.data
                .Departments
                .Where(d => d.Name == belongsToDepartment)
                .Select(d => d.Id)
                .FirstOrDefault();

            major.Name = name;
            major.Description = description;
            major.MajorType = majorType;
            major.Duration = duration;
            major.DepartmentId = departmentId;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var major = this.data.Majors.FindAsync(id);

            if (major == null)
            {
                return false;
            }

            this.data.Remove(major);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
