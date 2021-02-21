namespace UMS.Data.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using Common;
    using Common.Enumerations;
    using Common.Contracts;
    using static Common.DataValidation.Address;

    public class TeacherAddress : BaseAuditInfoModel, IAddress
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxStreetNameLength)]
        public string StreetName { get; set; }

        [MaxLength(MaxDistrictNameLength)]
        public string District { get; set; }

        [Required]
        [MaxLength(MaxTownNameLength)]
        public string Town { get; set; }

        [MaxLength(MaxPostalCodeLength)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(MaxCountryNameLength)]
        public string Country { get; set; }

        public Continent Continent { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
