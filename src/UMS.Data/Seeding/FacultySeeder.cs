﻿namespace UMS.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using static SeedingConstants.FacultySeedingConstants;

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

                    (FacultyOfMedicalScience.Name, FacultyOfMedicalScience.Description, FacultyOfMedicalScience.AddressStreetName, FacultyOfMedicalScience.AddressTownName, FacultyOfMedicalScience.AddressCountryName, FacultyOfMedicalScience.Email, FacultyOfMedicalScience.PhoneNumber, FacultyOfMedicalScience.Fax),

                    (FacultyOfSocialScience.Name, FacultyOfSocialScience.Description, FacultyOfSocialScience.AddressStreetName, FacultyOfSocialScience.AddressTownName, FacultyOfSocialScience.AddressCountryName, FacultyOfSocialScience.Email, FacultyOfSocialScience.PhoneNumber, FacultyOfSocialScience.Fax),

                    (FacultyOfPhilology.Name, FacultyOfPhilology.Description, FacultyOfPhilology.AddressStreetName, FacultyOfPhilology.AddressTownName, FacultyOfPhilology.AddressCountryName, FacultyOfPhilology.Email, FacultyOfPhilology.PhoneNumber, FacultyOfPhilology.Fax),

                    (FacultyOfHistory.Name, FacultyOfHistory.Description, FacultyOfHistory.AddressStreetName, FacultyOfHistory.AddressTownName, FacultyOfHistory.AddressCountryName, FacultyOfHistory.Email, FacultyOfHistory.PhoneNumber, FacultyOfHistory.Fax),

                    (FacultyOfMathematicsAndInformatics.Name, FacultyOfMathematicsAndInformatics.Description, FacultyOfMathematicsAndInformatics.AddressStreetName, FacultyOfMathematicsAndInformatics.AddressTownName, FacultyOfMathematicsAndInformatics.AddressCountryName, FacultyOfMathematicsAndInformatics.Email, FacultyOfMathematicsAndInformatics.PhoneNumber, FacultyOfMathematicsAndInformatics.Fax),

                    (FacultyOfTheology.Name, FacultyOfTheology.Description, FacultyOfTheology.AddressStreetName, FacultyOfTheology.AddressTownName, FacultyOfTheology.AddressCountryName, FacultyOfTheology.Email, FacultyOfTheology.PhoneNumber, FacultyOfTheology.Fax),

                    (FacultyOfPhilosophy.Name, FacultyOfPhilosophy.Description, FacultyOfPhilosophy.AddressStreetName, FacultyOfPhilosophy.AddressTownName, FacultyOfPhilosophy.AddressCountryName, FacultyOfPhilosophy.Email, FacultyOfPhilosophy.PhoneNumber, FacultyOfPhilosophy.Fax),

                    (FacultyOfPhysicsAndChemistry.Name, FacultyOfPhysicsAndChemistry.Description, FacultyOfPhysicsAndChemistry.AddressStreetName, FacultyOfPhysicsAndChemistry.AddressTownName, FacultyOfPhysicsAndChemistry.AddressCountryName, FacultyOfPhysicsAndChemistry.Email, FacultyOfPhysicsAndChemistry.PhoneNumber, FacultyOfPhysicsAndChemistry.Fax),

                    (FacultyOfEconomy.Name, FacultyOfEconomy.Description, FacultyOfEconomy.AddressStreetName, FacultyOfEconomy.AddressTownName, FacultyOfEconomy.AddressCountryName, FacultyOfEconomy.Email, FacultyOfEconomy.PhoneNumber, FacultyOfEconomy.Fax),
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
