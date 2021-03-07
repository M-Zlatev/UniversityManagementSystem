namespace UMS.Services.Data.Models.TeachersParametersModels
{
    using UMS.Data.Common.Enumerations;

    public abstract class TeacherBaseParametersModel : BaseAddress
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public AcademicDegree AcademicDegree { get; set; }

        public AcademicRank AcademicRank { get; set; }

        public string ImageUrl { get; set; }
    }
}
