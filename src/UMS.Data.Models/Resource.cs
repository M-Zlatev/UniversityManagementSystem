namespace UMS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Enumerations;
    using static UMS.Data.Common.DataValidation.Resource;

    public class Resource
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public int? CourseId { get; set; }

        public Course Course { get; set; }
    }
}
