namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;

    public class MajorService : IMajorService
    {
        private const int MajorPageSize = 10;

        private readonly UmsDbContext data;

        public MajorService(UmsDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage = MajorPageSize)
            => this.data
             .Majors
             .OrderBy(m => m.Id)
             .Skip((page - 1) * majorsPerPage)
             .Take(majorsPerPage)
             .To<T>()
             .ToList();

        //public async Task<MajorDetailsServiceModel> Details(int id)
        //    => await this.data.Majors
        //        .Where(m => m.Id == id)
        //        .ProjectTo<MajorDetailsServiceModel>(this.mapper.ConfigurationProvider)
        //        .FirstOrDefaultAsync();

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
