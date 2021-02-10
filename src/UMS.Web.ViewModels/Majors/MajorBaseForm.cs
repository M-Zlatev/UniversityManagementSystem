﻿namespace UMS.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    using UMS.Data.Common.Enumerations;
    using static Data.Common.DataValidation.Major;

    public abstract class MajorBaseForm
    {
        [Required]
        [MaxLength(MaxNameLength)]
        public string Name { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public MajorType MajorType { get; set; }

        [Range(MinRangeInYears, MaxRangeInYears)]
        public double Duration { get; set; }

        public string BelongsToDepartment { get; set; }
    }
}