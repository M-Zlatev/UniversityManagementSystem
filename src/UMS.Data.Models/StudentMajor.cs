namespace UMS.Data.Models
{
    public class StudentMajor
    {
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
    }
}
