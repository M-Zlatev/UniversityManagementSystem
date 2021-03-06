﻿namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data.Models.DepartmentsParametersModels;
    using Services.Mapping.Infrastructure;
    using UMS.Data.Models.Departments;
    using UMS.Data.Models.Faculties;
    using UMS.Data.Repositories.Contracts;

    public class DepartmentsService : IDepartmentsService
    {
        private const int DepartmentPageSize = 10;

        private readonly IDeletableEntityRepository<Department> departmentRepository;
        private readonly IDeletableEntityRepository<Faculty> facultyRepository;

        public DepartmentsService(
            IDeletableEntityRepository<Department> departmentRepository,
            IDeletableEntityRepository<Faculty> facultyRepository)
        {
            this.departmentRepository = departmentRepository;
            this.facultyRepository = facultyRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int departmentsPerPage = DepartmentPageSize)
            => this.departmentRepository.AllAsNoTracking()
             .OrderBy(d => d.Id)
             .Skip((page - 1) * departmentsPerPage)
             .Take(departmentsPerPage)
             .To<T>()
             .ToList();

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
           => this.facultyRepository.AllAsNoTracking()
           .Select(c => new
           {
               c.Id,
               c.Name,
           }).ToList()
           .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        public T GetDetailsById<T>(int id)
            => this.departmentRepository.AllAsNoTracking()
                .Where(d => d.Id == id)
                .To<T>()
                .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.departmentRepository.All().AnyAsync(d => d.Id == id);

        public int GetCount()
            => this.departmentRepository.All().Count();

        public async Task<int> CreateAsync(DepartmentCreateParametersModel model)
        {
            var facultyId = this.facultyRepository.All()
                .Where(f => f.Id == model.FacultyId)
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

            await this.departmentRepository.AddAsync(department);
            await this.departmentRepository.SaveChangesAsync();

            return department.Id;
        }

        public async Task<bool> EditAsync(int id, DepartmentEditParametersModel model)
        {
            var department = this.departmentRepository.All().FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return false;
            }

            department.Name = model.Name;
            department.Description = model.Description;
            department.Email = model.Email;
            department.PhoneNumber = model.PhoneNumber;
            department.Fax = model.Fax;

            await this.departmentRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var department = this.departmentRepository.All().FirstOrDefault(d => d.Id == id);

            if (department == null)
            {
                return false;
            }

            this.departmentRepository.Delete(department);

            await this.departmentRepository.SaveChangesAsync();

            return true;
        }
    }
}
