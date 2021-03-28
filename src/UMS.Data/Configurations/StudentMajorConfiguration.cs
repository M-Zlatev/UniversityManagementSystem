namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Students;

    public class StudentMajorConfiguration : IEntityTypeConfiguration<StudentMajor>
    {
        public void Configure(EntityTypeBuilder<StudentMajor> studentMajor)
        {
            studentMajor.HasKey(sm => new { sm.StudentId, sm.MajorId });

            studentMajor
                .HasOne(sm => sm.Student)
                .WithMany(s => s.Majors)
                .HasForeignKey(cm => cm.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            studentMajor
                .HasOne(sm => sm.Major)
                .WithMany(m => m.Students)
                .HasForeignKey(sm => sm.MajorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
