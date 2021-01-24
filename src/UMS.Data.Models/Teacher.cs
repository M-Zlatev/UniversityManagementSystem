namespace UMS.Data.Models
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using Common.Models;
    using static Common.DataValidation.Teacher;

    public class Teacher : BaseDeletableModel
    {
        public Teacher()
        {
            this.Courses = new HashSet<TeacherCourse>();
            this.Students = new HashSet<TeacherStudent>();
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

        public Gender Gender { get; set; }

        [Required]
        [Range(MinEmailAddressLength, MaxEmailAdressLength)]
        public string Email { get; set; }

        [Required]
        [Range(MinPhoneNumberLength, MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public AcademicDegree AcademicDegree { get; set; }

        [Required]
        public AcademicRank AcademicRank { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<TeacherStudent> Students { get; set; }

        public virtual ICollection<TeacherCourse> Courses { get; set; }
    }
}
