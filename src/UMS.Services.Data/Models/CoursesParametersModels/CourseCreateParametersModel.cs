namespace UMS.Services.Data.Models.CoursesParametersModels
{
    using System;

    public class CourseCreateParametersModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Price { get; set; }

        public string BelongsToMajor { get; set; }

        public string UserId { get; set; }
    }
}
