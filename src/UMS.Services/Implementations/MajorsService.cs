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
    using UMS.Services.Data.Models.MajorsParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;

    public class MajorsService : IMajorsService
    {
        private const int MajorPageSize = 10;

        private readonly UmsDbContext data;

        public MajorsService(UmsDbContext data)
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

        public T GetDetailsById<T>(int id)
            => this.data
                .Majors
                .Where(m => m.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.data.Majors.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Majors.AnyAsync(m => m.Id == id);

        public async Task<int> Create(MajorCreateParametersModel model)
        {
            var departmentId = this.data
                .Departments
                .Where(d => d.Name == model.BelongsToDepartment)
                .Select(d => d.Id)
                .FirstOrDefault();

            var major = new Major
            {
                Name = model.Name,
                Description = model.Description,
                MajorType = model.MajorType,
                Duration = model.Duration,
                DepartmentId = departmentId,
            };

            this.data.Add(major);

            await this.data.SaveChangesAsync();

            return major.Id;
        }

        public async Task<bool> Edit(int id, MajorEditParametersModel model)
        {
            var major = await this.data.Majors.FindAsync(id);

            if (major == null)
            {
                return false;
            }

            var departmentId = this.data
                .Departments
                .Where(d => d.Name == model.BelongsToDepartment)
                .Select(d => d.Id)
                .FirstOrDefault();

            major.Name = model.Name;
            major.Description = model.Description;
            major.MajorType = model.MajorType;
            major.Duration = model.Duration;
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
