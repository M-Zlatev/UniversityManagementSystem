namespace UMS.Data.Models
{
    public class TeacherCourse
    {
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
