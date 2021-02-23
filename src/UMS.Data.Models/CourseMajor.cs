namespace UMS.Data.Models
{
    using Common.Contracts;

    public class CourseMajor : BaseDeletableModel
    {
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public int MajorId { get; set; }

        public Major Major { get; set; }
    }
}
