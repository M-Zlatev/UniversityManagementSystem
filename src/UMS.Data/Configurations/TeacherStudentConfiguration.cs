namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Teachers;

    public class TeacherStudentConfiguration : IEntityTypeConfiguration<TeacherStudent>
    {
        public void Configure(EntityTypeBuilder<TeacherStudent> teacherStudent)
        {
            teacherStudent.HasKey(ts => new { ts.TeacherId, ts.StudentId });

            teacherStudent
                .HasOne(ts => ts.Teacher)
                .WithMany(ts => ts.Students)
                .HasForeignKey(ts => ts.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            teacherStudent
                .HasOne(ts => ts.Student)
                .WithMany(ts => ts.Teachers)
                .HasForeignKey(ts => ts.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
