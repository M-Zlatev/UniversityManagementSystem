namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Models.Departments;
    using UMS.Data;
    using UMS.Data.Models;

    public class DepartmentService : IDepartmentService
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

        public async Task<DepartmentDetailsServiceModel> Details(int id)
            => await this.data.Departments
                .Where(d => d.Id == id)
                .Select(d => new DepartmentDetailsServiceModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    Description = d.Description,
                    Email = d.Email,
                    PhoneNumber = d.PhoneNumber,
                    Fax = d.Fax,
                    BelongsToFaculty = d.Faculty.Name,
                })
                .FirstOrDefaultAsync();

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
