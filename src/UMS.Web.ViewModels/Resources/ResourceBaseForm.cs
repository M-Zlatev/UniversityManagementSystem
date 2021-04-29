namespace UMS.Web.ViewModels.Resources
{
    using System;

    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;
    using static Data.Common.DataValidation.Resource;

    public abstract class ResourceBaseForm
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Resource type")]
        public ResourceType ResourceType { get; set; }

        [Required]
        public string Url { get; set; }

        public string BelongToCourse { get; set; }

        public int UserId { get; set; }
    }
}
