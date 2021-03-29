namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using System;

    using Additional;
    using UMS.Data.Common.Enumerations;

    public abstract class StudentBaseParametersModel : BaseAddress
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UniformCivilNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }
    }
}
