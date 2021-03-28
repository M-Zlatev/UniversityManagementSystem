namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Teachers;

    public class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> teacherCourse)
        {
            teacherCourse.HasKey(tc => new { tc.TeacherId, tc.CourseId });

            teacherCourse
                .HasOne(tc => tc.Teacher)
                .WithMany(tc => tc.Courses)
                .HasForeignKey(tc => tc.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            teacherCourse
                .HasOne(tc => tc.Course)
                .WithMany(tc => tc.Teachers)
                .HasForeignKey(tc => tc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
