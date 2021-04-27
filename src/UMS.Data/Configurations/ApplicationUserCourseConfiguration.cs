namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.UserDefinedPrincipal;

    public class ApplicationUserCourseConfiguration : IEntityTypeConfiguration<ApplicationUserCourse>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserCourse> appUserCourse)
        {
            appUserCourse.HasKey(um => new { um.UserId, um.CourseId });

            appUserCourse
                .HasOne(uc => uc.User)
                .WithMany(u => u.Courses)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            appUserCourse
                .HasOne(uc => uc.Course)
                .WithMany(c => c.User)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
