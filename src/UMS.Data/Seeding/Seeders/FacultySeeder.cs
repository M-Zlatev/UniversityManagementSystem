namespace UMS.Data.Seeders.Seeding
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Seeding;
    using Models.Faculties;
    using UMS.Data.Seeding.Factories;

    public class FacultySeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Faculties.Any())
            {
                return;
            }

            var facultyFactory = new FacultyFactory();
            var faculties = facultyFactory.CreateEntities();

            // necessary cast for data manipulation in the AddAsyncFacultiesInDb method below
            var facultiesAfterCast = (List<(string Name, string Description, string AddressStreetName, string AddressTownName,
            string AddressCountryName, string Email, string PhoneNumber, string Fax)>)faculties;

            await AddAsyncFacultiesInDb(dbContext, facultiesAfterCast);
        }

        private static async Task AddAsyncFacultiesInDb(UmsDbContext dbContext, List<(string Name, string Description, string AddressStreetName, string AddressTownName, string AddressCountryName, string Email, string PhoneNumber, string Fax)> faculties)
        {
            foreach (var faculty in faculties)
            {
                FacultyAddress facultyAddress = new FacultyAddress()
                {
                    StreetName = faculty.AddressStreetName,
                    Town = faculty.AddressTownName,
                    Country = faculty.AddressCountryName,
                };

                await dbContext.Faculties.AddAsync(new Faculty
                {
                    Name = faculty.Name,
                    Description = faculty.Description,
                    Address = facultyAddress,
                    Email = faculty.Email,
                    PhoneNumber = faculty.PhoneNumber,
                    Fax = faculty.Fax,
                });
            }
        }
    }
}
