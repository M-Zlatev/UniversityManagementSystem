namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;
    using Models.Students;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student
                .HasOne(st => st.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<StudentAddress>(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            student
                .HasMany(st => st.Homeworks)
                .WithOne(h => h.Student)
                .HasForeignKey(h => h.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
