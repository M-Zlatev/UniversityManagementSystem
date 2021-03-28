namespace UMS.Data.Seeders.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Seeding;
    using Data.Seeding.Factories;
    using Models.Departments;

    public class DepartmentSeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            var departmentFactory = new DepartmentFactory();
            var departments = departmentFactory.CreateEntities();

            // necessary cast for data manipulation in the AddAsyncDepartmentsInDb method below
            var departmentsAfterCast = (List<(string Name, string Description, string Email, string PhoneNumber, string Fax, int FacultyId)>)departments;

            await AddAsyncDepartmentsInDb(dbContext, departmentsAfterCast);
        }

        private static async Task AddAsyncDepartmentsInDb(UmsDbContext dbContext, List<(string Name, string Description, string Email, string PhoneNumber, string Fax, int FacultyId)> departments)
        {
            foreach (var department in departments)
            {
                await dbContext.Departments.AddAsync(new Department
                {
                    Name = department.Name,
                    Description = department.Description,
                    Email = department.Email,
                    PhoneNumber = department.PhoneNumber,
                    Fax = department.Fax,
                    FacultyId = department.FacultyId,
                });
            }
        }
    }
}
