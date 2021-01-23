﻿namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Models;
    using static Common.DataValidation.Faculty;

    public class Faculty : BaseModel
    {
        public Faculty()
        {
            this.Departments = new HashSet<Department>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        [Range(MinEmailAddressLength, MaxEmailAdressLength)]
        public string Email { get; set; }

        [Required]
        [Range(MinPhoneNumberLength, MaxPhoneNumberLength)]
        public string PhoneNumber { get; set; }

        [Required]
        [Range(MinFaxNumberLength, MaxFaxNumberLength)]
        public string Fax { get; set; }

        public virtual ICollection<Department> Departments { get; set; }
    }
}
