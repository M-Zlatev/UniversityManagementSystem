namespace UMS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static UMS.Data.Common.DataValidation.Major;

    public class Major
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
