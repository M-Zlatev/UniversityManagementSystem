namespace UMS.Data.Seeding.Factories
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using Common.Enumerations;
    using static SeedingConstants.MajorSeedingConstants;

    public class MajorFactory : IFactory
    {
        public ICollection CreateEntities()
        {
            var majors = new List<(string Name, double Duration, MajorType MajorDegreeType, int departmentId)>
            {
                // Art and Design Majors
                (FineArts.Name, FineArts.Duration, FineArts.MajorDegreeType, FineArts.DepartmentId),
                (Design.Name, Design.Duration, Design.MajorDegreeType, Design.DepartmentId),
                (ArtsAndDesignManagement.Name, ArtsAndDesignManagement.Duration, ArtsAndDesignManagement.MajorDegreeType, ArtsAndDesignManagement.DepartmentId),

                // Applied Art Majors
                (VisualArts.Name, VisualArts.Duration, VisualArts.MajorDegreeType, VisualArts.DepartmentId),
                (AppliedArtsMaster.Name, AppliedArtsMaster.Duration, AppliedArtsMaster.MajorDegreeType, AppliedArtsMaster.DepartmentId),

                // Theater And Film Majors
                (PerformingArts.Name, PerformingArts.Duration, PerformingArts.MajorDegreeType, PerformingArts.DepartmentId),
                (PerformingArtsMaster.Name, PerformingArtsMaster.Duration, PerformingArtsMaster.MajorDegreeType, PerformingArtsMaster.DepartmentId),

                // Department of Private Law
                (CivilLaw.Name, CivilLaw.Duration, CivilLaw.MajorDegreeType, CivilLaw.DepartmentId),
                (LabourLaw.Name, LabourLaw.Duration, LabourLaw.MajorDegreeType, LabourLaw.DepartmentId),
                (CorporationLaw.Name, CorporationLaw.Duration, CorporationLaw.MajorDegreeType, CorporationLaw.DepartmentId),
                (CompetitionLaw.Name, CompetitionLaw.Duration, ConstitutionalLaw.MajorDegreeType, CompetitionLaw.DepartmentId),
                (PrivateLawMaster.Name, PrivateLawMaster.Duration, PrivateLawMaster.MajorDegreeType, PrivateLawMaster.DepartmentId),

                // Department of Public Law
                (AdminsitrativeLaw.Name, AdminsitrativeLaw.Duration, AdminsitrativeLaw.MajorDegreeType, AdminsitrativeLaw.DepartmentId),
                (CommercialLaw.Name, CommercialLaw.Duration, ConstitutionalLaw.MajorDegreeType, CommercialLaw.DepartmentId),
                (TaxLaw.Name, TaxLaw.Duration, TaxLaw.MajorDegreeType, TaxLaw.DepartmentId),
                (PublicLawMaster.Name, PublicLawMaster.Duration, PublicLawMaster.MajorDegreeType, PublicLawMaster.DepartmentId),

                // Department of Criminal Law
                (CriminalLaw.Name, CriminalLaw.Duration, CriminalLaw.MajorDegreeType, CriminalLaw.DepartmentId),
                (ConstitutionalLaw.Name, ConstitutionalLaw.Duration, ConstitutionalLaw.MajorDegreeType, ConstitutionalLaw.DepartmentId),
                (CriminalLawMaster.Name, CriminalLawMaster.Duration, CriminalLawMaster.MajorDegreeType, CriminalLawMaster.DepartmentId),

                // Department of International Law
                (BusinessLaw.Name, BusinessLaw.Duration, BusinessLaw.MajorDegreeType, BusinessLaw.DepartmentId),
                (EnvironmentalLaw.Name, EnvironmentalLaw.Duration, EnvironmentalLaw.MajorDegreeType, EnvironmentalLaw.DepartmentId),
                (HumanRightsLaw.Name, HumanRightsLaw.Duration, HumanRightsLaw.MajorDegreeType, HumanRightsLaw.DepartmentId),
                (InternationalLawMaster.Name, InternationalLawMaster.Duration, InternationalLawMaster.MajorDegreeType, InternationalLawMaster.DepartmentId),

                // Department of Medicine
                (Surgery.Name, Surgery.Duration, Surgery.MajorDegreeType, Surgery.DepartmentId),
                (Gynaecology.Name, Gynaecology.Duration, Gynaecology.MajorDegreeType, Gynaecology.DepartmentId),
                (Pediatrics.Name, Pediatrics.Duration, Pediatrics.MajorDegreeType, Pediatrics.DepartmentId),
                (Pathology.Name, Pathology.Duration, Pathology.MajorDegreeType, Pathology.DepartmentId),
                (MedicineMaster.Name, MedicineMaster.Duration, MedicineMaster.MajorDegreeType, MedicineMaster.DepartmentId),
                (MedicineDoctor.Name, MedicineDoctor.Duration, MedicineDoctor.MajorDegreeType, MedicineDoctor.DepartmentId),

                // Department of Pharmacy
                (Pharmacology.Name, Pharmacology.Duration, Pharmacology.MajorDegreeType, Pharmacology.DepartmentId),
                (PharmacologyMaster.Name, PharmacologyMaster.Duration, PharmacologyMaster.MajorDegreeType, PharmacologyMaster.DepartmentId),

                // Department of Dental Medicine
                (DentalScience.Name, DentalScience.Duration, DentalScience.MajorDegreeType, DentalScience.DepartmentId),
                (DentalScienceMaster.Name, DentalScienceMaster.Duration, DentalScienceMaster.MajorDegreeType, DentalScienceMaster.DepartmentId),

                // Department of Anthropology
                (Anthropology.Name, Anthropology.Duration, Anthropology.MajorDegreeType, Anthropology.DepartmentId),
                (AnthropologyMaster.Name, AnthropologyMaster.Duration, AnthropologyMaster.MajorDegreeType, AnthropologyMaster.DepartmentId),

                // Department of Sociology
                (Sociology.Name, Sociology.Duration, Sociology.MajorDegreeType, Sociology.DepartmentId),
                (SociologyMaster.Name, SociologyMaster.Duration, SociologyMaster.MajorDegreeType, SociologyMaster.DepartmentId),

                // Department of Romance Langugages
                (RomancePhilology.Name, RomancePhilology.Duration, RomancePhilology.MajorDegreeType, RomancePhilology.DepartmentId),
                (RomanceTranslatology.Name, RomanceTranslatology.Duration, RomanceTranslatology.MajorDegreeType, RomanceTranslatology.DepartmentId),

                // Department of Germanic Langugages
                (GermanPhilology.Name, GermanPhilology.Duration, GermanPhilology.MajorDegreeType, GermanPhilology.DepartmentId),
                (GermanTranslatology.Name, GermanTranslatology.Duration, GermanTranslatology.MajorDegreeType, GermanTranslatology.DepartmentId),

                // Department of Slavic Langugages
                (SlavicPhilology.Name, SlavicPhilology.Duration, SlavicPhilology.MajorDegreeType, SlavicPhilology.DepartmentId),
                (SlavicTranslatology.Name, SlavicTranslatology.Duration, SlavicTranslatology.MajorDegreeType, SlavicTranslatology.DepartmentId),

                // Department of Asian Langugages
                (AsianPhilology.Name, AsianPhilology.Duration, AsianPhilology.MajorDegreeType, AsianPhilology.DepartmentId),
                (AsianTranslatology.Name, AsianTranslatology.Duration, AsianTranslatology.MajorDegreeType, AsianTranslatology.DepartmentId),

                // Department of African Langugages
                (AfricanPhilology.Name, AfricanPhilology.Duration, AfricanPhilology.MajorDegreeType, AfricanPhilology.DepartmentId),
                (AfricanTranslatology.Name, AfricanTranslatology.Duration, AfricanTranslatology.MajorDegreeType, AfricanTranslatology.DepartmentId),

                // Department of Isolate languages
                (IsolateLanguagesPhilology.Name, IsolateLanguagesPhilology.Duration, IsolateLanguagesPhilology.MajorDegreeType, IsolateLanguagesPhilology.DepartmentId),
                (IsolateLanguagesTranslatology.Name, IsolateLanguagesTranslatology.Duration, IsolateLanguagesTranslatology.MajorDegreeType, IsolateLanguagesTranslatology.DepartmentId),

                // Department of Dead languages
                (AncientLanguages.Name, AncientLanguages.Duration, AncientLanguages.MajorDegreeType, AncientLanguages.DepartmentId),
                (AncientLanguagesMasters.Name, AncientLanguagesMasters.Duration, AncientLanguagesMasters.MajorDegreeType, AncientLanguagesMasters.DepartmentId),

                // Department of History
                (History.Name, History.Duration, History.MajorDegreeType, History.DepartmentId),
                (HistoryMaster.Name, HistoryMaster.Duration, HistoryMaster.MajorDegreeType, History.DepartmentId),

                // Department of Archeology
                (Archeology.Name, Archeology.Duration, Archeology.MajorDegreeType, Archeology.DepartmentId),
                (ArcheologyMaster.Name, ArcheologyMaster.Duration, ArcheologyMaster.MajorDegreeType, ArcheologyMaster.DepartmentId),

                // Department of Ethnology
                (Ethnology.Name, Ethnology.Duration, Ethnology.MajorDegreeType, Ethnology.DepartmentId),
                (EthnologyMaster.Name, EthnologyMaster.Duration, EthnologyMaster.MajorDegreeType, EthnologyMaster.DepartmentId),

                // Department of Mathematics
                (Mathematics.Name, Mathematics.Duration, Mathematics.MajorDegreeType, Mathematics.DepartmentId),
                (MathMaster.Name, MathMaster.Duration, MathMaster.MajorDegreeType, MathMaster.DepartmentId),

                // Department of Informatics
                (Cybersecurity.Name, Cybersecurity.Duration, Cybersecurity.MajorDegreeType, Cybersecurity.DepartmentId),
                (InformationTechnology.Name, InformationTechnology.Duration, InformationTechnology.MajorDegreeType, InformationTechnology.DepartmentId),
                (InformaticsMaster.Name, InformaticsMaster.Duration, InformaticsMaster.MajorDegreeType, InformaticsMaster.DepartmentId),

                // Department of Theology
                (Theology.Name, Theology.Duration, Theology.MajorDegreeType, Theology.DepartmentId),
                (TheologyMaster.Name, TheologyMaster.Duration, TheologyMaster.MajorDegreeType, TheologyMaster.DepartmentId),

                // Department of Philosophy
                (Philosophy.Name, Philosophy.Duration, Philosophy.MajorDegreeType, Philosophy.DepartmentId),
                (PhilosophyMaster.Name, PhilosophyMaster.Duration, PhilosophyMaster.MajorDegreeType, PhilosophyMaster.DepartmentId),

                // Department of Psychology
                (Psychology.Name, Psychology.Duration, Psychology.MajorDegreeType, Psychology.DepartmentId),
                (PsychologyMaster.Name, PsychologyMaster.Duration, PsychologyMaster.MajorDegreeType, PsychologyMaster.DepartmentId),

                // Department of Physics
                (ConstructionManagement.Name, ConstructionManagement.Duration,
                  ConstructionManagement.MajorDegreeType, ConstructionManagement.DepartmentId),
                (AeronauticsAndAstronautics.Name, AeronauticsAndAstronautics.Duration,
                  AeronauticsAndAstronautics.MajorDegreeType, AeronauticsAndAstronautics.DepartmentId),
                (PhysicsMaster.Name, PhysicsMaster.Duration, PhysicsMaster.MajorDegreeType, PhysicsMaster.DepartmentId),

                // Department of Chemistry
                (ChemicalEngineering.Name, ChemicalEngineering.Duration, ChemicalEngineering.MajorDegreeType, ChemicalEngineering.DepartmentId),
                (ChemistryMaster.Name, ChemistryMaster.Duration, ChemistryMaster.MajorDegreeType, ChemistryMaster.DepartmentId),

                // Department of Economy
                (Accounting.Name, Accounting.Duration, Accounting.MajorDegreeType, Accounting.DepartmentId),
                (Marketing.Name, Marketing.Duration, Marketing.MajorDegreeType, Marketing.DepartmentId),
                (Management.Name, Management.Duration, Management.MajorDegreeType, Management.DepartmentId),
            };

            return majors;
        }
    }
}
