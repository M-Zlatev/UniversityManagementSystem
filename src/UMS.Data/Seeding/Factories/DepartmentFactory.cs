namespace UMS.Data.Seeding.Factories
{
    using System.Collections;
    using System.Collections.Generic;

    using static SeedingConstants.DepartmentSeedingConstants;

    public class DepartmentFactory : IFactory
    {
        public ICollection CreateEntities()
        {
            var departments = new List<(
                string Name,
                string Description,
                string Email,
                string PhoneNumber,
                string Fax,
                int FacultyId)>
            {
                // Faculty of Art's departments
                (DepartmentOfArtAndDesign.Name, DepartmentOfArtAndDesign.Description, DepartmentOfArtAndDesign.Email, DepartmentOfArtAndDesign.PhoneNumber, DepartmentOfArtAndDesign.Fax, DepartmentOfArtAndDesign.FacultyId),

                (DepartmentOfAppliedArts.Name, DepartmentOfAppliedArts.Description, DepartmentOfAppliedArts.Email, DepartmentOfAppliedArts.PhoneNumber, DepartmentOfAppliedArts.Fax, DepartmentOfAppliedArts.FacultyId),

                (DepartmentOfTheaterAndFilm.Name, DepartmentOfTheaterAndFilm.Description, DepartmentOfTheaterAndFilm.Email, DepartmentOfTheaterAndFilm.PhoneNumber, DepartmentOfTheaterAndFilm.Fax, DepartmentOfTheaterAndFilm.FacultyId),

                // Faculty of Law's departments
                (DepartmentOfPrivateLaw.Name, DepartmentOfPrivateLaw.Description, DepartmentOfPrivateLaw.Email, DepartmentOfPrivateLaw.PhoneNumber, DepartmentOfPrivateLaw.Fax, DepartmentOfPrivateLaw.FacultyId),

                (DepartmentOfPublicLaw.Name, DepartmentOfPublicLaw.Description, DepartmentOfPublicLaw.Email, DepartmentOfPublicLaw.PhoneNumber, DepartmentOfPublicLaw.Fax, DepartmentOfPublicLaw.FacultyId),

                (DepartmentOfCriminalLaw.Name, DepartmentOfCriminalLaw.Description, DepartmentOfCriminalLaw.Email, DepartmentOfCriminalLaw.PhoneNumber, DepartmentOfCriminalLaw.Fax, DepartmentOfCriminalLaw.FacultyId),

                (DepartmentOfInternationalLaw.Name, DepartmentOfInternationalLaw.Description,
                  DepartmentOfInternationalLaw.Email, DepartmentOfInternationalLaw.PhoneNumber,
                  DepartmentOfInternationalLaw.Fax, DepartmentOfInternationalLaw.FacultyId),

                // Faculty of Medical Science's departments
                (DepartmentOfMedicine.Name, DepartmentOfMedicine.Description, DepartmentOfMedicine.Email, DepartmentOfMedicine.PhoneNumber, DepartmentOfMedicine.Fax, DepartmentOfMedicine.FacultyId),

                (DepartmentOfDentalMedicine.Name, DepartmentOfDentalMedicine.Description, DepartmentOfDentalMedicine.Email, DepartmentOfDentalMedicine.PhoneNumber, DepartmentOfDentalMedicine.Fax, DepartmentOfDentalMedicine.FacultyId),

                (DepartmentOfPharmacy.Name, DepartmentOfPharmacy.Description, DepartmentOfPharmacy.Email, DepartmentOfPharmacy.PhoneNumber, DepartmentOfPharmacy.Fax, DepartmentOfPharmacy.FacultyId),

                (DepartmentOfPublicHealth.Name, DepartmentOfPublicHealth.Description, DepartmentOfPublicHealth.Email, DepartmentOfPublicHealth.PhoneNumber, DepartmentOfPublicHealth.Fax, DepartmentOfPublicHealth.FacultyId),

                // Faculty of Social Science's departments
                (DepartmentOfAnthropology.Name, DepartmentOfAnthropology.Description, DepartmentOfAnthropology.Email, DepartmentOfAnthropology.PhoneNumber, DepartmentOfAnthropology.Fax, DepartmentOfAnthropology.FacultyId),

                (DepartmentOfPsychologicalSciences.Name, DepartmentOfPsychologicalSciences.Description, DepartmentOfPsychologicalSciences.Email, DepartmentOfPsychologicalSciences.PhoneNumber, DepartmentOfPsychologicalSciences.Fax, DepartmentOfPsychologicalSciences.FacultyId),

                (DepartmentOfSociology.Name, DepartmentOfSociology.Description, DepartmentOfSociology.Email, DepartmentOfSociology.PhoneNumber, DepartmentOfSociology.Fax, DepartmentOfSociology.FacultyId),

                // Faculty of Philology's Departments
                (DepartmentOfRomanceLanguages.Name, DepartmentOfRomanceLanguages.Description,
                  DepartmentOfRomanceLanguages.Email, DepartmentOfRomanceLanguages.PhoneNumber,
                  DepartmentOfRomanceLanguages.Fax, DepartmentOfRomanceLanguages.FacultyId),

                (DepartmentOfGermanicLanguages.Name, DepartmentOfGermanicLanguages.Description, DepartmentOfGermanicLanguages.Email, DepartmentOfGermanicLanguages.PhoneNumber, DepartmentOfGermanicLanguages.Fax, DepartmentOfGermanicLanguages.FacultyId),

                (DepartmentOfSlavicLanguages.Name, DepartmentOfSlavicLanguages.Description,
                  DepartmentOfSlavicLanguages.Email, DepartmentOfSlavicLanguages.PhoneNumber,
                  DepartmentOfSlavicLanguages.Fax, DepartmentOfSlavicLanguages.FacultyId),

                (DepartmentOfAsianLanguages.Name, DepartmentOfAsianLanguages.Description, DepartmentOfAsianLanguages.Email, DepartmentOfAsianLanguages.PhoneNumber, DepartmentOfAsianLanguages.Fax, DepartmentOfAsianLanguages.FacultyId),

                (DepartmentOfAfricanLanguages.Name, DepartmentOfAfricanLanguages.Description,
                  DepartmentOfAfricanLanguages.Email, DepartmentOfAfricanLanguages.PhoneNumber,
                  DepartmentOfAfricanLanguages.Fax, DepartmentOfAfricanLanguages.FacultyId),

                (DepartmentOfIsolateLanguages.Name, DepartmentOfIsolateLanguages.Description,
                  DepartmentOfIsolateLanguages.Email, DepartmentOfIsolateLanguages.PhoneNumber,
                  DepartmentOfIsolateLanguages.Fax, DepartmentOfIsolateLanguages.FacultyId),

                (DepartmentOfDeadLanguages.Name, DepartmentOfDeadLanguages.Description, DepartmentOfDeadLanguages.Email, DepartmentOfDeadLanguages.PhoneNumber, DepartmentOfDeadLanguages.Fax, DepartmentOfDeadLanguages.FacultyId),

                // Faculty of History's Departments
                (DepartmentOfGeneralHistory.Name, DepartmentOfGeneralHistory.Description, DepartmentOfGeneralHistory.Email, DepartmentOfGeneralHistory.PhoneNumber, DepartmentOfGeneralHistory.Fax, DepartmentOfGeneralHistory.FacultyId),

                (DepartmentOfArcheology.Name, DepartmentOfArcheology.Description, DepartmentOfArcheology.Email, DepartmentOfArcheology.PhoneNumber, DepartmentOfArcheology.Fax, DepartmentOfArcheology.FacultyId),

                (DepartmentOfEthnology.Name, DepartmentOfEthnology.Description, DepartmentOfEthnology.Email, DepartmentOfEthnology.PhoneNumber, DepartmentOfEthnology.Fax, DepartmentOfEthnology.FacultyId),

                // Faculty of Mathematics And Informatics' Departments
                (DepartmentOfMathematics.Name, DepartmentOfMathematics.Description, DepartmentOfMathematics.Email, DepartmentOfMathematics.PhoneNumber, DepartmentOfMathematics.Fax, DepartmentOfMathematics.FacultyId),

                (DepartmentOfInformatics.Name, DepartmentOfInformatics.Description, DepartmentOfInformatics.Email, DepartmentOfInformatics.PhoneNumber, DepartmentOfInformatics.Fax, DepartmentOfInformatics.FacultyId),

                // Faculty of Theology's Departments
                (DepartmentOfTheology.Name, DepartmentOfTheology.Description, DepartmentOfTheology.Email, DepartmentOfTheology.PhoneNumber, DepartmentOfTheology.Fax, DepartmentOfTheology.FacultyId),

                (DepartmentOfReligion.Name, DepartmentOfReligion.Description, DepartmentOfReligion.Email, DepartmentOfReligion.PhoneNumber, DepartmentOfReligion.Fax, DepartmentOfReligion.FacultyId),

                // Faculty of Philosophy's Departments
                (DepartmentOfPhilosophy.Name, DepartmentOfPhilosophy.Description, DepartmentOfPhilosophy.Email, DepartmentOfPhilosophy.PhoneNumber, DepartmentOfPhilosophy.Fax, DepartmentOfPhilosophy.FacultyId),

                (DepartmentOfPsychology.Name, DepartmentOfPsychology.Description, DepartmentOfPsychology.Email, DepartmentOfPsychology.PhoneNumber, DepartmentOfPsychology.Fax, DepartmentOfPsychology.FacultyId),

                // Faculty of Physics and Chemistry
                (DepartmentOfPhysics.Name, DepartmentOfPhysics.Description, DepartmentOfPhysics.Email, DepartmentOfPhysics.PhoneNumber, DepartmentOfPhysics.Fax, DepartmentOfPhysics.FacultyId),

                (DepartmentOfChemistry.Name, DepartmentOfChemistry.Description, DepartmentOfChemistry.Email, DepartmentOfChemistry.PhoneNumber, DepartmentOfChemistry.Fax, DepartmentOfChemistry.FacultyId),

                // Faculty of Economy
                (DepartmentOfEconomy.Name, DepartmentOfEconomy.Description, DepartmentOfEconomy.Email, DepartmentOfEconomy.PhoneNumber, DepartmentOfEconomy.Fax, DepartmentOfEconomy.FacultyId),
            };

            return departments;
        }
    }
}
