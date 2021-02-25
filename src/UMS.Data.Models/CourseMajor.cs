namespace UMS.Data.Models
{
    public class CourseMajor
    {
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
    }
}
