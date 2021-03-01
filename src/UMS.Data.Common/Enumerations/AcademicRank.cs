namespace UMS.Data.Common.Enumerations
{
    using System.ComponentModel.DataAnnotations;

    public enum AcademicRank
    {
        [Display(Name = "Associate lecturer")]
        AssociateLecturer = 0,
        Lecturer = 1,
        [Display(Name = "Senior lecturer")]
        SeniorLecturer = 2,
        [Display(Name = "Associate professor")]
        AssociateProfessor = 3,
        Professor = 4,
    }
}
