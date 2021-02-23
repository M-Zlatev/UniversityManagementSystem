namespace UMS.Data.Models
{
    using Common.Contracts;

    public class TeacherStudent : BaseDeletableModel
    {
        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}
