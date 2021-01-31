namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Common;

    public class MajorService : IMajorService
    {
        private const int MajorPageSize = 10;

        private readonly UmsDbContext data;
        private readonly IMapper mapper;

        public MajorService(UmsDbContext data, IMapper mapper)
        {
            this.data = data;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<IListModel>> All(int page)
            => await this.data
                .Majors
                .Skip((page - 1) * MajorPageSize)
                .Take(MajorPageSize)
                .ProjectTo<IListModel>(this.mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<IListModel> Details(int id)
            => await this.data.Majors
                .Where(m => m.Id == id)
                .ProjectTo<IListModel>(this.mapper.ConfigurationProvider)
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
