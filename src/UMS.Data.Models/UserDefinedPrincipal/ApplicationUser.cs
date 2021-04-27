namespace UMS.Data.Models.UserDefinedPrincipal
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Identity;

    using Common.Contracts;
    using Common.Enumerations;
    using Homeworks;
    using static Data.Common.DataValidation.ApplicationUser;

    public class ApplicationUser : IdentityUser<int>, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Roles = new HashSet<IdentityUserRole<int>>();
            this.Claims = new HashSet<IdentityUserClaim<int>>();
            this.Logins = new HashSet<IdentityUserLogin<int>>();

            this.Courses = new HashSet<ApplicationUserCourse>();
            this.Majors = new HashSet<ApplicationUserMajor>();
            this.Homeworks = new HashSet<Homework>();
        }

        // User common properties
        [Required]
        [MaxLength(MaxNameLength)]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public ApplicationUserAddress Address { get; set; }

        public string ImageUrl { get; set; }

        // User in role - Teacher properties
        public AcademicDegree AcademicDegree { get; set; }

        public AcademicRank AcademicRank { get; set; }

        // User in role - Student properties
        [Required]
        [StringLength(MaxUCNLength, MinimumLength = MinUCNLength, ErrorMessage = UCNErrorMessage)]
        public string UniformCivilNumber { get; set; }

        public bool HasScholarship { get; set; }

        // IAuditInfo implementation
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // IDeletableEntity implementation
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        // Additional Application user properties
        public virtual ICollection<ApplicationUserMajor> Majors { get; set; }

        public virtual ICollection<ApplicationUserCourse> Courses { get; set; }

        public virtual ICollection<Homework> Homeworks { get; set; }

        // Additional Identity user properties
        public virtual ICollection<IdentityUserRole<int>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
    }
}
