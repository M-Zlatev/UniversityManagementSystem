namespace UMS.Data.Models
{
    using Common.Contracts;

    public class StudentMajor : BaseDeletableModel
    {
        public int StudentId { get; set; }

        public Student Student { get; set; }

        public int MajorId { get; set; }

        public Major Major { get; set; }
    }
}
