﻿namespace UMS.Services.Data.Models.StudentsParametersModels
{
    using System;

    using UMS.Data.Common.Enumerations;

    public abstract class StudentBaseParametersModel
    {
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string UniformCivilNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender Gender { get; set; }

        public string AddressStreetName { get; set; }

        public string AddressTownName { get; set; }

        public string AddressDistrictName { get; set; }

        public string AddressCountryName { get; set; }

        public Continent AddressContinentName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string ImageUrl { get; set; }

        public bool HasScholarship { get; set; }
    }
}
