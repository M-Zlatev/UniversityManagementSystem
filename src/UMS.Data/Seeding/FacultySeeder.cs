namespace UMS.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using static FacultySeedingConstants;

    public class FacultySeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Faculties.Any())
            {
                return;
            }

            var faculties =
                new List<(string Name,
                string Description,
                string AddressStreetName,
                string AddressTownName,
                string AddressCountryName,
                string Email,
                string PhoneNumber,
                string Fax)>
            {
                    (FacultyOfArts.Name, FacultyOfArts.Description, FacultyOfArts.AddressStreetName, FacultyOfArts.AddressTownName, FacultyOfArts.AddressCountryName, FacultyOfArts.Email, FacultyOfArts.PhoneNumber, FacultyOfArts.Fax),
                    (FacultyOfLaw.Name, FacultyOfLaw.Description, FacultyOfLaw.AddressStreetName, FacultyOfLaw.AddressTownName, FacultyOfLaw.AddressCountryName, FacultyOfLaw.Email, FacultyOfLaw.PhoneNumber, FacultyOfLaw.Fax),
            };

            foreach (var faculty in faculties)
            {
                Address facultyAddress = new Address()
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
