namespace UMS.Data.Models.UserDefinedPrincipal
{
    using Courses;

    public class ApplicationUserCourse
    {
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
