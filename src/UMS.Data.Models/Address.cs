namespace UMS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static UMS.Data.Common.DataValidation.Address;

    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxStreetNameLength)]
        public string StreetName { get; set; }

        [Required]
        [MaxLength(MaxTownNameLength)]
        public string Town { get; set; }

        [Required]
        [MaxLength(MaxCountryNameLength)]
        public string Country { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }

        public int? TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}
