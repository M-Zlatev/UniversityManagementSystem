namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class FacultyConfiguration : IEntityTypeConfiguration<Faculty>
    {
        public void Configure(EntityTypeBuilder<Faculty> faculty)
        {
            faculty
                .HasMany(f => f.Departments)
                .WithOne(d => d.Faculty)
                .HasForeignKey(d => d.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);

            faculty
                .HasOne(f => f.Address)
                .WithOne(a => a.Faculty)
                .HasForeignKey<FacultyAddress>(a => a.FacultyId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
