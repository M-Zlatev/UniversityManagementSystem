﻿namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using static Common.DataValidation.Address;

    public class TeacherAddress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxStreetNameLength, MinimumLength = MinStreetNameLength)]
        public string StreetName { get; set; }

        [MaxLength(MaxDistrictNameLength)]
        public string District { get; set; }

        [Required]
        [StringLength(MaxTownNameLength, MinimumLength = MinTownNameLength)]
        public string Town { get; set; }

        [StringLength(MaxPostalCodeLength, MinimumLength = MinPostalCodeLength)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(MaxCountryNameLength, MinimumLength = MinCountryNameLength)]
        public string Country { get; set; }

        public Continent Continent { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
