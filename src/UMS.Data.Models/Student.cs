namespace UMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using static UMS.Data.Common.DataValidation.Student;

    public class Student
    {
        public Student()
        {
            this.RegistrationDate = DateTime.UtcNow;
            this.CourseEnrollments = new HashSet<StudentCourse>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "This field must contains 10 digits")]
        public int UniformCivilNumber { get; set; }

        public DateTime? DateofBirth { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        [MaxLength(MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        public bool HasScholarship { get; set; }

        public DateTime RegistrationDate { get; set; }

        public ICollection<StudentCourse> CourseEnrollments { get; set; }
    }
}
