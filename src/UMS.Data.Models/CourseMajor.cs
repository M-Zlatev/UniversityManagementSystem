namespace UMS.Data.Models
{
    public class CourseMajor
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int MajorId { get; set; }

        public Major Major { get; set; }
    }
}
