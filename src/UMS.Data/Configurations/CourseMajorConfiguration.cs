namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class CourseMajorConfiguration : IEntityTypeConfiguration<CourseMajor>
    {
        public void Configure(EntityTypeBuilder<CourseMajor> courseMajor)
        {
            courseMajor.HasKey(cm => new { cm.CourseId, cm.MajorId });

            courseMajor
                .HasOne(cm => cm.Course)
                .WithMany(c => c.Majors)
                .HasForeignKey(cm => cm.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            courseMajor
                .HasOne(cm => cm.Major)
                .WithMany(m => m.Courses)
                .HasForeignKey(cm => cm.MajorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
