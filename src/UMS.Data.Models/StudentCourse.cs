namespace UMS.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.Common.DataValidation.Course;

    public class StudentCourse
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Range(MinGrade, MaxGrade)]
        public double? Grade { get; set; }
    }
}
