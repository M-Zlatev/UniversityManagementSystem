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

        public async Task<int> Create(string name, string description, string email, string phoneNumber, string fax, string belongsToFaculty, string userId)
        {
            var facultyId = this.data
                .Faculties
                .Where(f => f.Name == belongsToFaculty)
                .Select(f => f.Id)
                .FirstOrDefault();

            var department = new Department
            {
                Name = name,
                Description = description,
                Email = email,
                PhoneNumber = phoneNumber,
                Fax = fax,
                FacultyId = facultyId,
            };

            this.data.Add(department);

            await this.data.SaveChangesAsync();

            return department.Id;
        }

        public async Task<bool> Edit(int id, string name, string description, string email, string phoneNumber, string fax)
        {
            var department = await this.data.Departments.FindAsync(id);

            if (department == null)
            {
                return false;
            }

            department.Name = name;
            department.Description = description;
            department.Email = email;
            department.PhoneNumber = phoneNumber;
            department.Fax = fax;

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
