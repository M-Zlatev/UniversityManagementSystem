﻿namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using System;

    using UMS.Data.Common.Enumerations;

    public class StudentCreateParametersModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int UniformCivilNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressCountryName { get; set; }

        public string AddressContinentName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }

        public string MajorName { get; set; }

        public int StringId { get; set; }
    }
}
