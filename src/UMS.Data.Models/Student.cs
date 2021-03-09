namespace UMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using Common.Implementations;
    using static Common.DataValidation.Student;

    public class Student : BaseDeletableModel
    {
        public Student()
        {
            this.RegistrationDate = DateTime.UtcNow;
            this.Majors = new HashSet<StudentMajor>();
            this.Teachers = new HashSet<TeacherStudent>();
            this.CourseEnrollments = new HashSet<StudentCourse>();
            this.Homeworks = new HashSet<Homework>();
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
        [StringLength(MaxUCNLength, MinimumLength = MinUCNLength, ErrorMessage = UCNErrorMessage)]
        public string UniformCivilNumber { get; set; }

        public DateTime? DateofBirth { get; set; }

        public Gender Gender { get; set; }

        [Required]
        public StudentAddress Address { get; set; }

        [Required]
        [StringLength(MaxPhoneNumberLength, MinimumLength = MinPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(MaxEmailAdressLength, MinimumLength = MinEmailAddressLength)]
        [EmailAddress]
        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }

        public DateTime RegistrationDate { get; set; }

        public virtual ICollection<StudentMajor> Majors { get; set; }

        public virtual ICollection<StudentCourse> CourseEnrollments { get; set; }

        public virtual ICollection<TeacherStudent> Teachers { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }
    }
}
