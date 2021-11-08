namespace UMS.Web.ViewModels.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using System.ComponentModel.DataAnnotations;
    using AutoMapper;

    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models.UserDefinedPrincipal;
    using UMS.Services.Mapping.Contracts;
    using static Data.Common.DataValidation.Address;
    using static Data.Common.DataValidation.ApplicationUser;

    public class EditUserViewModel : IMapFrom<ApplicationUser>, IMapExplicitly
    {
        public EditUserViewModel()
        {
            this.Claims = new List<string>();
            this.Roles = new List<string>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [MaxLength(MaxNameLength)]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Street { get; set; }

        public string District { get; set; }

        public string Town { get; set; }

        [Display(Name = "Postal Code")]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(MaxCountryNameLength, MinimumLength = MinCountryNameLength)]
        public string Country { get; set; }

        public Continent Continent { get; set; }

        [Display(Name = "Date of birth")]
        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        // Store last time the user visited the page
        [Display(Name = "Last visited login time")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? LastVisitedLoginTime { get; set; }

        [Display(Name = "Image Url")]
        public string ImageUrl { get; set; }

        // User in role - Teacher properties
        [Display(Name = "Academic Degree")]
        public AcademicDegree AcademicDegree { get; set; }

        [Display(Name = "Academic Rank")]
        public AcademicRank AcademicRank { get; set; }

        // User in role - Student properties
        [Display(Name = "Faculty number")]
        public string FacultyNumber { get; set; }

        [Display(Name = "Has Scholarship")]
        public bool HasScholarship { get; set; }

        [Display(Name = "Created on")]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified on")]
        public DateTime? ModifiedOn { get; set; }

        // IDeletableEntity implementation
        [Display(Name = "Is deleted")]
        public bool IsDeleted { get; set; }

        [Display(Name = "Deleted on")]
        public DateTime? DeletedOn { get; set; }

        public IList<string> Claims { get; set; }

        public IList<string> Roles { get; set; }

        public void CreateMappings(IProfileExpression profile)
        {
            profile.CreateMap<ApplicationUser, EditUserViewModel>()
                .ForMember(vm => vm.Street, cfg => cfg.MapFrom(u => u.Address.StreetName))
                .ForMember(vm => vm.District, cfg => cfg.MapFrom(u => u.Address.District))
                .ForMember(vm => vm.Town, cfg => cfg.MapFrom(u => u.Address.Town))
                .ForMember(vm => vm.PostalCode, cfg => cfg.MapFrom(u => u.Address.PostalCode))
                .ForMember(vm => vm.Country, cfg => cfg.MapFrom(u => u.Address.Country))
                .ForMember(vm => vm.Continent, cfg => cfg.MapFrom(u => u.Address.Continent))
                .ForMember(vm => vm.Claims, cfg => cfg.MapFrom(u => u.Claims.Select(c => c.ClaimValue).ToList()))
                .ForMember(vm => vm.Roles, cfg => cfg.MapFrom(
                    u => u.Roles.Select(r => r.RoleId.ToString()).ToList()));
        }
    }
}
