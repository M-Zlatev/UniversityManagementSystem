namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> teacher)
        {
            teacher
                .HasOne(t => t.Address)
                .WithOne(a => a.Teacher)
                .HasForeignKey<Address>(a => a.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
