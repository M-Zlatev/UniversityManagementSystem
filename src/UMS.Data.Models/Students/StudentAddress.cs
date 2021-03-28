namespace UMS.Data.Models.Students
{
    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using static Common.DataValidation.Address;

    public class StudentAddress
    {
        public int Id { get; set; }

        [Required]
        [StringLength(MaxStreetNameLength, MinimumLength = MinStreetNameLength)]
        public string StreetName { get; set; }

        [StringLength(MaxDistrictNameLength, MinimumLength = MinDistrictNameLength)]
        public string District { get; set; }

        [StringLength(MaxPostalCodeLength, MinimumLength = MinPostalCodeLength)]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(MaxTownNameLength, MinimumLength = MinTownNameLength)]
        public string Town { get; set; }

        [Required]
        [StringLength(MaxCountryNameLength, MinimumLength = MinCountryNameLength)]
        public string Country { get; set; }

        public Continent Continent { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
