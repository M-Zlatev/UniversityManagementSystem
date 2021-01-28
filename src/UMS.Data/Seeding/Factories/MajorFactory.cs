namespace UMS.Data.Seeding.Factories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using static SeedingConstants.MajorSeedingConstants;

    public class MajorFactory : IFactory
    {
        public ICollection CreateEntities()
        {
            var majors = new List<(string Name, double Duration, int departmentId)>
            {
                // Art and Design Majors
                (FineArts.Name, FineArts.Duration, FineArts.DepartmentId),
                (Design.Name, Design.Duration, Design.DepartmentId),

                // Applied Art Majors
                (VisualArts.Name, VisualArts.Duration, VisualArts.DepartmentId),

                // Theater And Film Majors
                (PerformingArts.Name, PerformingArts.Duration, PerformingArts.DepartmentId),

                // Department of Private Law
                (CivilLaw.Name, CivilLaw.Duration, CivilLaw.DepartmentId),
                (LabourLaw.Name, LabourLaw.Duration, LabourLaw.DepartmentId),
                (CorporationLaw.Name, CorporationLaw.Duration, CorporationLaw.DepartmentId),
                (CompetitionLaw.Name, CompetitionLaw.Duration, CompetitionLaw.DepartmentId),

                // Department of Public Law
                (AdminsitrativelLaw.Name, AdminsitrativelLaw.Duration, AdminsitrativelLaw.DepartmentId),
                (CommercialLaw.Name, CommercialLaw.Duration, CommercialLaw.DepartmentId),
                (TaxLaw.Name, TaxLaw.Duration, TaxLaw.DepartmentId),

                // Department of Criminal Law
                (CriminallLaw.Name, CriminallLaw.Duration, CriminallLaw.DepartmentId),
                (ConstitutionalLaw.Name, ConstitutionalLaw.Duration, ConstitutionalLaw.DepartmentId),

                // Department of International Law
                (BusinessLaw.Name, BusinessLaw.Duration, BusinessLaw.DepartmentId),
                (EnvironmentalLaw.Name, EnvironmentalLaw.Duration, EnvironmentalLaw.DepartmentId),
                (HumanRightsLaw.Name, HumanRightsLaw.Duration, HumanRightsLaw.DepartmentId),

                // Department of Pharmacy
                (Pharmacology.Name, Pharmacology.Duration, Pharmacology.DepartmentId),

                // Department of Dental Medicine
                (DentalScience.Name, DentalScience.Duration, DentalScience.DepartmentId),

                // Department of Anthropology
                (Anthropology.Name, Anthropology.Duration, Anthropology.DepartmentId),

                // Department of Sociology
                (Sociology.Name, Sociology.Duration, Sociology.DepartmentId),

                // Department of Germanic Langugages
                (EnglishPhilology.Name, EnglishPhilology.Duration, EnglishPhilology.DepartmentId),
                (GermanPhilology.Name, GermanPhilology.Duration, GermanPhilology.DepartmentId),
                (NorthGermanicPhilology.Name, NorthGermanicPhilology.Duration, NorthGermanicPhilology.DepartmentId),

                // Department of Dead languages
                (AncientLanguages.Name, AncientLanguages.Duration, AncientLanguages.DepartmentId),

                // Department of Archeology
                (Archeology.Name, Archeology.Duration, Archeology.DepartmentId),

                // Department of Ethnology
                (Ethnology.Name, Ethnology.Duration, Ethnology.DepartmentId),

                // Department of Mathematics
                (ActuarialMathematics.Name, ActuarialMathematics.Duration, ActuarialMathematics.DepartmentId),

                // Department of Informatics
                (Cybersecurity.Name, Cybersecurity.Duration, Cybersecurity.DepartmentId),
                (InformationTechnology.Name, InformationTechnology.Duration, InformationTechnology.DepartmentId),

                // Department of Theology
                (Theology.Name, Theology.Duration, Theology.DepartmentId),

                // Department of Philosophy
                (Philosophy.Name, Philosophy.Duration, Philosophy.DepartmentId),

                // Department of Psychology
                (Psychology.Name, Psychology.Duration, Psychology.DepartmentId),

                // Department of Chemistry
                (ChemicalEngineering.Name, ChemicalEngineering.Duration, ChemicalEngineering.DepartmentId),

                // Department of Physics
                (ConstructionManagement.Name, ConstructionManagement.Duration, ConstructionManagement.DepartmentId),
                (AeronauticsAndAstronautics.Name, AeronauticsAndAstronautics.Duration, AeronauticsAndAstronautics.DepartmentId),

                // Department of Economy
                (Accounting.Name, Accounting.Duration, Accounting.DepartmentId),
                (Marketing.Name, Marketing.Duration, Marketing.DepartmentId),
                (Management.Name, Management.Duration, Management.DepartmentId),
            };

            return majors;
        }
    }
}
