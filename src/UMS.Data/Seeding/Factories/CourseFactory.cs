namespace UMS.Data.Seeding.Factories
{
    using System.Collections;
    using System.Collections.Generic;

    using static SeedingConstants.CourseSeedingConstants;

    public class CourseFactory : IFactory
    {
        public ICollection CreateEntities()
        {
            var courses = new List<(string Name, decimal Price, int MajorId)>
            {
                // Master in Dental science
                (Dentistry.Name, Dentistry.Price, Dentistry.MajorId),

                // Master in Archeology
                (DataAnalyst.Name, DataAnalyst.Price, DataAnalyst.MajorId),

                // Archeology
                (CulturalLandscapes.Name, CulturalLandscapes.Price, CulturalLandscapes.MajorId),
                (Surveying.Name, Surveying.Price, Surveying.MajorId),
                (Excavation.Name, Excavation.Price, Excavation.MajorId),

                // Master in History
                (GeneralHistory.Name, GeneralHistory.Price, GeneralHistory.MajorId),

                // History
                (AncientHistory.Name, AncientHistory.Price, AncientHistory.MajorId),
                (EarlyModernHistory.Name, EarlyModernHistory.Price, EarlyModernHistory.MajorId),
                (ModernHistory.Name, ModernHistory.Price, ModernHistory.MajorId),

                // Master in Ancient languages
                (ALTranslatology.Name, ALTranslatology.Price, ALTranslatology.MajorId),

                // Ancient languages
                (Latin.Name, Latin.Price, Latin.MajorId),
                (AncientGreek.Name, AncientGreek.Price, AncientGreek.MajorId),

                // Translatology with Isolate languages
                (ILTranslatology.Name, ILTranslatology.Price, ILTranslatology.MajorId),

                // Isolate languages Philology
                (ModernGreek.Name, ModernGreek.Price, ModernGreek.MajorId),
                (Albanian.Name, Albanian.Price, Albanian.MajorId),
                (Armenian.Name, Armenian.Price, Armenian.MajorId),

                // Translatology with African languages
                (AFTranslatology.Name, AFTranslatology.Price, AFTranslatology.MajorId),

                // African languages Philology
                (NigerCongo.Name, NigerCongo.Price, NigerCongo.MajorId),
                (NiloSaharan.Name, NiloSaharan.Price, NiloSaharan.MajorId),
                (KhoeKwadi.Name, KhoeKwadi.Price, KhoeKwadi.MajorId),

                // Translatology with Asian languages
                (ASTranslatology.Name, ASTranslatology.Price, ASTranslatology.MajorId),

                // Asian languages Philology
                (Japanese.Name, Japanese.Price, Japanese.MajorId),
                (Mandarin.Name, Mandarin.Price, Mandarin.MajorId),
                (MiddleEast.Name, MiddleEast.Price, MiddleEast.MajorId),

                // Translatology with Slavic languages
                (SLTranslatology.Name, SLTranslatology.Price, SLTranslatology.MajorId),

                // Slavic languages Philology
                (EastSlavic.Name, EastSlavic.Price, EastSlavic.MajorId),
                (WestSlavic.Name, WestSlavic.Price, WestSlavic.MajorId),
                (SouthSlavic.Name, SouthSlavic.Price, SouthSlavic.MajorId),

                // Translatology with Germanic languages
                (GTranslatology.Name, GTranslatology.Price, GTranslatology.MajorId),

                // Ethnology
                (Folklore.Name, Folklore.Price, Folklore.MajorId),
                (CSurvival.Name, CSurvival.Price, CSurvival.MajorId),

                // Germanic languages Philology
                (English.Name, English.Price, English.MajorId),
                (German.Name, German.Price, German.MajorId),
                (NorthGL.Name, NorthGL.Price, NorthGL.MajorId),

                // Master in Ethnology
                (CCS.Name, CCS.Price, CCS.MajorId),

                // Master in Mathematics
                (MathSciences.Name, MathSciences.Price, MathSciences.MajorId),

                // Accounting
                (FAccounting.Name, FAccounting.Price, FAccounting.MajorId),
                (Audit.Name, Audit.Price, Audit.MajorId),
                (MAccounting.Name, MAccounting.Price, MAccounting.MajorId),
                (TaxAccounting.Name, TaxAccounting.Price, TaxAccounting.MajorId),
                (CostAccounting.Name, CostAccounting.Price, CostAccounting.MajorId),

                // Master in Chemistry
                (ChemicalEngineering.Name, ChemicalEngineering.Price, ChemicalEngineering.MajorId),

                // Chemical Engineering
                (Alchemy.Name, Alchemy.Price, Alchemy.MajorId),
                (ModernChemistry.Name, ModernChemistry.Price, ModernChemistry.MajorId),

                // Master in Physics
                (EngineeringPhysics.Name, EngineeringPhysics.Price, EngineeringPhysics.MajorId),

                // Aeronautics & Astronautics
                (AerospaceEngineering.Name, AerospaceEngineering.Price, AerospaceEngineering.MajorId),

                // Construction Management
                (FOPP.Name, FOPP.Price, FOPP.MajorId),
                (RiskManagement.Name, RiskManagement.Price, RiskManagement.MajorId),
                (ProjectControl.Name, ProjectControl.Price, ProjectControl.MajorId),

                // Master in Psychology
                (PSciences.Name, PSciences.Price, PSciences.MajorId),

                // Psychology
                (TheScienceOfWellBeing.Name, TheScienceOfWellBeing.Price, TheScienceOfWellBeing.MajorId),

                // Master in Philosophy
                (PhSciences.Name, PhSciences.Price, PhSciences.MajorId),

                // Philosophy
                (PhMethods.Name, PhMethods.Price, PhMethods.MajorId),
                (Metaphysics.Name, Metaphysics.Price, Metaphysics.MajorId),
                (LEA.Name, LEA.Price, LEA.MajorId),

                // Master in Theology
                (TSciences.Name, TSciences.Price, TSciences.MajorId),

                // Theology
                (BublicalStudies.Name, BublicalStudies.Price, BublicalStudies.MajorId),

                // Master in Informatics
                (EInformatics.Name, EInformatics.Price, EInformatics.MajorId),

                // Information technology
                (CHardware.Name, CHardware.Price, CHardware.MajorId),
                (CSoftware.Name, CSoftware.Price, CSoftware.MajorId),

                // Cybersecurity
                (CSecurity.Name, CSecurity.Price, CSecurity.MajorId),
                (SARisk.Name, SARisk.Price, SARisk.MajorId),

                // Mathematics
                (Algebra.Name, Algebra.Price, Algebra.MajorId),
                (Geometry.Name, Geometry.Price, Geometry.MajorId),
                (StatisticsAndProbability.Name, StatisticsAndProbability.Price, StatisticsAndProbability.MajorId),

                // Translatology with Romance languages
                (RTranslatology.Name, RTranslatology.Price, RTranslatology.MajorId),

                // Romance languages Philology
                (French.Name, French.Price, French.MajorId),
                (Spanish.Name, Spanish.Price, Spanish.MajorId),
                (Italic.Name, Italic.Price, Italic.MajorId),
                (Portuguese.Name, Portuguese.Price, Portuguese.MajorId),
                (Romanian.Name, Romanian.Price, Romanian.MajorId),

                // Master in Sociology
                (SocialScince.Name, SocialScince.Price, SocialScince.MajorId),

                // Constitutional Law
                (Conventions.Name, Conventions.Price, Conventions.MajorId),
                (CLaw.Name, CLaw.Price, CLaw.MajorId),
                (JMLaw.Name, JMLaw.Price, JMLaw.MajorId),

                // Master in Criminal Law
                (Criminology.Name, Criminology.Price, Criminology.MajorId),

                // Business Law
                (MercantileLaw.Name, MercantileLaw.Price, MercantileLaw.MajorId),

                // Environmental Law
                (AQualityLaw.Name, AQualityLaw.Price, AQualityLaw.MajorId),
                (WQualityLaw.Name, WQualityLaw.Price, WQualityLaw.MajorId),
                (ECleanupLaw.Name, ECleanupLaw.Price, ECleanupLaw.MajorId),

                // Human Rights
                (HumanRights.Name, HumanRights.Price, HumanRights.MajorId),

                // Master in International Law
                (ILawStudies.Name, ILawStudies.Price, ILawStudies.MajorId),

                // General Surgery
                (SurgicalCriticalCare.Name, SurgicalCriticalCare.Price, SurgicalCriticalCare.MajorId),
                (LaparoscopicSurgery.Name, LaparoscopicSurgery.Price, LaparoscopicSurgery.MajorId),
                (VascularSurgery.Name, VascularSurgery.Price, VascularSurgery.MajorId),
                (TransplantSurgery.Name, TransplantSurgery.Price, TransplantSurgery.MajorId),
                (CardiothoracicSurgery.Name, CardiothoracicSurgery.Price, CardiothoracicSurgery.MajorId),

                // Obstetrics and Gynecology
                (Obstetrics.Name, Obstetrics.Price, Obstetrics.MajorId),
                (Gynecology.Name, Gynecology.Price, Gynecology.MajorId),

                // Pediatrics
                (Neonatology.Name, Neonatology.Price, Neonatology.MajorId),
                (PCare.Name, PCare.Price, PCare.MajorId),

                // Pathology
                (FPathology.Name, FPathology.Price, FPathology.MajorId),
                (SPathology.Name, SPathology.Price, SPathology.MajorId),
                (CPathology.Name, CPathology.Price, CPathology.MajorId),

                // Master in Medicine
                (MedicalStudies.Name, MedicalStudies.Price, MedicalStudies.MajorId),

                // Doctor of Medicine
                (DMedical.Name, DMedical.Price, DMedical.MajorId),

                // Pharmacology
                (TPharmacology.Name, TPharmacology.Price, TPharmacology.MajorId),
                (CPharmacology.Name, CPharmacology.Price, CPharmacology.MajorId),

                // Master in Pharmacology
                (PharmaStudies.Name, PharmaStudies.Price, PharmaStudies.MajorId),

                // Dental science
                (Odontology.Name, Odontology.Price, Odontology.MajorId),

                // Criminal Law
                (ScopeCriminalLiablity.Name, ScopeCriminalLiablity.Price, ScopeCriminalLiablity.MajorId),
                (SeverityOfOffense.Name, SeverityOfOffense.Price, SeverityOfOffense.MajorId),
                (CrimeAgainstProperty.Name, CrimeAgainstProperty.Price, CrimeAgainstProperty.MajorId),
                (CrimeAgainstPublic.Name, CrimeAgainstPublic.Price, CrimeAgainstPublic.MajorId),

                // Master in Public Law
                (PublicLawStudies.Name, PublicLawStudies.Price, PublicLawStudies.MajorId),

                // Tax Law
                (InternalRevenue.Name, InternalRevenue.Price, InternalRevenue.MajorId),

                // Commercial Law
                (Commerce.Name, Commerce.Price, Commerce.MajorId),
                (Trade.Name, Trade.Price, Trade.MajorId),

                // Sociology
                (SocialStructure.Name, SocialStructure.Price, SocialStructure.MajorId),
                (SocialOrder.Name, SocialOrder.Price, SocialOrder.MajorId),
                (SocialPolicy.Name, SocialPolicy.Price, SocialPolicy.MajorId),

                // Master in Anthropology
                (AnthropologicalSciences.Name, AnthropologicalSciences.Price, AnthropologicalSciences.MajorId),

                // Anthropology
                (CulturalAnthropology.Name, CulturalAnthropology.Price, CulturalAnthropology.MajorId),
                (SocialAnthropology.Name, SocialAnthropology.Price, SocialAnthropology.MajorId),

                // Fine Arts
                (ArtHistory.Name, ArtHistory.Price, ArtHistory.MajorId),
                (BaroqueArt.Name, BaroqueArt.Price, BaroqueArt.MajorId),
                (Architecture.Name, Architecture.Price, Architecture.MajorId),
                (Poetry.Name, Poetry.Price, Poetry.MajorId),

                // Design
                (IndustrialDesign.Name, IndustrialDesign.Price, IndustrialDesign.MajorId),
                (FashionDesign.Name, FashionDesign.Price, FashionDesign.MajorId),
                (InteriorDesign.Name, InteriorDesign.Price, InteriorDesign.MajorId),

                // Master in Arts and Design Management
                (ArtsAndDesignManagement.Name, ArtsAndDesignManagement.Price, ArtsAndDesignManagement.MajorId),

                // Visual Arts
                (Paint.Name, Paint.Price, Paint.MajorId),
                (Drawing.Name, Drawing.Price, Drawing.MajorId),
                (Sculpture.Name, Sculpture.Price, Sculpture.MajorId),

                // Marketing
                (Advertising.Name, Advertising.Price, Advertising.MajorId),
                (Branding.Name, Branding.Price, Branding.MajorId),
                (MobileMarket.Name, MobileMarket.Price, MobileMarket.MajorId),

                // Master in Applied Arts
                (AppliedArtsScience.Name, AppliedArtsScience.Price, AppliedArtsScience.MajorId),

                // Master in Performing Arts
                (PerformingArtsScience.Name, PerformingArtsScience.Price, PerformingArtsScience.MajorId),

                // Civil Law
                (CustodyDisputes.Name, CustodyDisputes.Price, CustodyDisputes.MajorId),
                (PropertyDamage.Name, PropertyDamage.Price, PropertyDamage.MajorId),

                // Labour Law
                (IndividualLabourLaw.Name, IndividualLabourLaw.Price, IndividualLabourLaw.MajorId),
                (CollectiveLabourLaw.Name, CollectiveLabourLaw.Price, CollectiveLabourLaw.MajorId),
                (InternationalLabourLaw.Name, InternationalLabourLaw.Price, InternationalLabourLaw.MajorId),

                // Corporation Law
                (CompanyLawTheory.Name, CompanyLawTheory.Price, CompanyLawTheory.MajorId),

                // Competition Law
                (CompetitionLawTheory.Name, CompetitionLawTheory.Price, CompetitionLawTheory.MajorId),

                // Master in Private Law
                (PrivateLawStudies.Name, PrivateLawStudies.Price, PrivateLawStudies.MajorId),

                // Administrative Law
                (LawAndLegalPrinciples.Name, LawAndLegalPrinciples.Price, LawAndLegalPrinciples.MajorId),

                // Performing Arts
                (Dance.Name, Dance.Price, Dance.MajorId),
                (Theatre.Name, Theatre.Price, Theatre.MajorId),
                (Film.Name, Film.Price, Film.MajorId),

                // Management
                (BusinessEntities.Name, BusinessEntities.Price, BusinessEntities.MajorId),
                (CorporateGovernance.Name, CorporateGovernance.Price, CorporateGovernance.MajorId),
            };

            return courses;
        }
    }
}
