namespace UMS.Services.Models.Majors
{
    using System.ComponentModel.DataAnnotations;

    using Data.Common.Enumerations;

    public class MajorDetailsServiceModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public MajorType MajorType { get; set; }

        public double Duration { get; set; }

        public string BelongsToDepartment { get; set; }
    }
}
