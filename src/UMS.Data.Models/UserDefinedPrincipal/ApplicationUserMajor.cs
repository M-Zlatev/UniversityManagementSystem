namespace UMS.Data.Models.UserDefinedPrincipal
{
    using Majors;

    public class ApplicationUserMajor
    {
        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int MajorId { get; set; }

        public virtual Major Major { get; set; }
    }
}
