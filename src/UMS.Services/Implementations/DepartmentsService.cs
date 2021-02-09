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
    using Services.Data.Models.DepartmentsParametersModels;
    using UMS.Data;
    using UMS.Data.Models;

    public class DepartmentsService : IDepartmentsService
    {
        private const int DepartmentPageSize = 10;

        private readonly UmsDbContext data;

        public DepartmentsService(UmsDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<T> GetAll<T>(int page, int departmentsPerPage = DepartmentPageSize)
            => this.data
             .Departments
             .OrderBy(d => d.Id)
             .Skip((page - 1) * departmentsPerPage)
             .Take(departmentsPerPage)
             .To<T>()
             .ToList();

        public T GetDetails<T>(int id)
            => this.data
                .Departments
                .Where(d => d.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.data.Departments.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Departments.AnyAsync(d => d.Id == id);

        public async Task<int> Create(DepartmentCreateParametersModel model)
        {
            var facultyId = this.data
                .Faculties
                .Where(f => f.Name == model.BelongsToFaculty)
                .Select(f => f.Id)
                .FirstOrDefault();

            var department = new Department
            {
                Name = model.Name,
                Description = model.Description,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Fax = model.Fax,
                FacultyId = facultyId,
            };

            this.data.Add(department);

            await this.data.SaveChangesAsync();

            return department.Id;
        }

        public async Task<bool> Edit(int id, DepartmentEditParametersModel model)
        {
            var department = await this.data.Departments.FindAsync(id);

            if (department == null)
            {
                return false;
            }

            department.Name = model.Name;
            department.Description = model.Description;
            department.Email = model.Email;
            department.PhoneNumber = model.PhoneNumber;
            department.Fax = model.Fax;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var department = this.data.Departments.FindAsync(id);

            if (department == null)
            {
                return false;
            }

            this.data.Remove(department);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
