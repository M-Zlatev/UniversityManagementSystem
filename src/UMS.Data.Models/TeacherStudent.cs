namespace UMS.Data.Models
{
    public class TeacherStudent
    {
        public int TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }
    }
}
