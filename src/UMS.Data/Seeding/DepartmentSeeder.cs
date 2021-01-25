namespace UMS.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using static SeedingConstants.DepartmentSeedingConstants.DepartmentSeedingConstants;

    public class DepartmentSeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Departments.Any())
            {
                return;
            }

            var departments = new List<(string Name, string Description, string Email, string PhoneNumber, string Fax)>
            {
                // Faculty of Art's departments
                (DepartmentOfArtAndDesign.Name, DepartmentOfArtAndDesign.Description, DepartmentOfArtAndDesign.Email, DepartmentOfArtAndDesign.PhoneNumber, DepartmentOfArtAndDesign.Fax),

                (DepartmentOfAppliedArts.Name, DepartmentOfAppliedArts.Description, DepartmentOfAppliedArts.Email, DepartmentOfAppliedArts.PhoneNumber, DepartmentOfAppliedArts.Fax),

                (DepartmentOfTheaterAndFilm.Name, DepartmentOfTheaterAndFilm.Description, DepartmentOfTheaterAndFilm.Email, DepartmentOfTheaterAndFilm.PhoneNumber, DepartmentOfTheaterAndFilm.Fax),

                // Faculty of Law's departments
                (DepartmentOfPrivateLaw.Name, DepartmentOfPrivateLaw.Description, DepartmentOfPrivateLaw.Email, DepartmentOfPrivateLaw.PhoneNumber, DepartmentOfPrivateLaw.Fax),

                (DepartmentOfPublicLaw.Name, DepartmentOfPublicLaw.Description, DepartmentOfPublicLaw.Email, DepartmentOfPublicLaw.PhoneNumber, DepartmentOfPublicLaw.Fax),

                (DepartmentOfCriminalLaw.Name, DepartmentOfCriminalLaw.Description, DepartmentOfCriminalLaw.Email, DepartmentOfCriminalLaw.PhoneNumber, DepartmentOfCriminalLaw.Fax),

                (DepartmentOfInternationalLaw.Name, DepartmentOfInternationalLaw.Description, DepartmentOfInternationalLaw.Email, DepartmentOfInternationalLaw.PhoneNumber, DepartmentOfInternationalLaw.Fax),

                // Faculty of Medical Science's departments
                (DepartmentOfMedicine.Name, DepartmentOfMedicine.Description, DepartmentOfMedicine.Email, DepartmentOfMedicine.PhoneNumber, DepartmentOfMedicine.Fax),

                (DepartmentOfDentalMedicine.Name, DepartmentOfDentalMedicine.Description, DepartmentOfDentalMedicine.Email, DepartmentOfDentalMedicine.PhoneNumber, DepartmentOfDentalMedicine.Fax),

                (DepartmentOfPharmacy.Name, DepartmentOfPharmacy.Description, DepartmentOfPharmacy.Email, DepartmentOfPharmacy.PhoneNumber, DepartmentOfPharmacy.Fax),

                (DepartmentOfPublicHealth.Name, DepartmentOfPublicHealth.Description, DepartmentOfPublicHealth.Email, DepartmentOfPublicHealth.PhoneNumber, DepartmentOfPublicHealth.Fax),

                // Faculty of Social Science's departments
                (DepartmentOfAnthropology.Name, DepartmentOfAnthropology.Description, DepartmentOfAnthropology.Email, DepartmentOfAnthropology.PhoneNumber, DepartmentOfAnthropology.Fax),

                (DepartmentOfPsychologicalSciences.Name, DepartmentOfPsychologicalSciences.Description, DepartmentOfPsychologicalSciences.Email, DepartmentOfPsychologicalSciences.PhoneNumber, DepartmentOfPsychologicalSciences.Fax),

                (DepartmentOfSociology.Name, DepartmentOfSociology.Description, DepartmentOfSociology.Email, DepartmentOfSociology.PhoneNumber, DepartmentOfSociology.Fax),

                // Faculty of Philology's Departments
                (DepartmentOfRomanceLanguages.Name, DepartmentOfRomanceLanguages.Description, DepartmentOfRomanceLanguages.Email, DepartmentOfRomanceLanguages.PhoneNumber, DepartmentOfRomanceLanguages.Fax),

                (DepartmentOfGermanicLanguages.Name, DepartmentOfGermanicLanguages.Description, DepartmentOfGermanicLanguages.Email, DepartmentOfGermanicLanguages.PhoneNumber, DepartmentOfGermanicLanguages.Fax),

                (DepartmentOfSlavicLanguages.Name, DepartmentOfSlavicLanguages.Description, DepartmentOfSlavicLanguages.Email, DepartmentOfSlavicLanguages.PhoneNumber, DepartmentOfSlavicLanguages.Fax),

                (DepartmentOfAsianLanguages.Name, DepartmentOfAsianLanguages.Description, DepartmentOfAsianLanguages.Email, DepartmentOfAsianLanguages.PhoneNumber, DepartmentOfAsianLanguages.Fax),

                (DepartmentOfAfricanLanguages.Name, DepartmentOfAfricanLanguages.Description, DepartmentOfAfricanLanguages.Email, DepartmentOfAfricanLanguages.PhoneNumber, DepartmentOfAfricanLanguages.Fax),

                (DepartmentOfIsolateLanguages.Name, DepartmentOfIsolateLanguages.Description, DepartmentOfIsolateLanguages.Email, DepartmentOfIsolateLanguages.PhoneNumber, DepartmentOfIsolateLanguages.Fax),

                (DepartmentOfDeadLanguages.Name, DepartmentOfDeadLanguages.Description, DepartmentOfDeadLanguages.Email, DepartmentOfDeadLanguages.PhoneNumber, DepartmentOfDeadLanguages.Fax),

                // Faculty of History's Departments
                (DepartmentOfGeneralHistory.Name, DepartmentOfGeneralHistory.Description, DepartmentOfGeneralHistory.Email, DepartmentOfGeneralHistory.PhoneNumber, DepartmentOfGeneralHistory.Fax),

                (DepartmentOfArcheology.Name, DepartmentOfArcheology.Description, DepartmentOfArcheology.Email, DepartmentOfArcheology.PhoneNumber, DepartmentOfArcheology.Fax),

                (DepartmentOfEthnology.Name, DepartmentOfEthnology.Description, DepartmentOfEthnology.Email, DepartmentOfEthnology.PhoneNumber, DepartmentOfEthnology.Fax),

                // Faculty of Mathematics And Informatics' Departments
                (DepartmentOfMathematics.Name, DepartmentOfMathematics.Description, DepartmentOfMathematics.Email, DepartmentOfMathematics.PhoneNumber, DepartmentOfMathematics.Fax),

                (DepartmentOfInformatics.Name, DepartmentOfInformatics.Description, DepartmentOfInformatics.Email, DepartmentOfInformatics.PhoneNumber, DepartmentOfInformatics.Fax),

                // Faculty of Theology's Departments
                (DepartmentOfTheology.Name, DepartmentOfTheology.Description, DepartmentOfTheology.Email, DepartmentOfTheology.PhoneNumber, DepartmentOfTheology.Fax),

                (DepartmentOfReligion.Name, DepartmentOfReligion.Description, DepartmentOfReligion.Email, DepartmentOfReligion.PhoneNumber, DepartmentOfReligion.Fax),
            };

            foreach (var department in departments)
            {

                await dbContext.Departments.AddAsync(new Department
                {
                    Name = department.Name,
                    Description = department.Description,
                    Email = department.Email,
                    PhoneNumber = department.PhoneNumber,
                    Fax = department.Fax,
                });
            }
        }
    }
}
