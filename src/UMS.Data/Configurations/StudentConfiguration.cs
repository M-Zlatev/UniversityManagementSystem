namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> student)
        {
            student
                .HasOne(s => s.Address)
                .WithOne(a => a.Student)
                .HasForeignKey<Address>(a => a.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
