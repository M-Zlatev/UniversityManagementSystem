namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models;

    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> department)
        {
            department
                .HasMany(d => d.Majors)
                .WithOne(m => m.Department)
                .HasForeignKey(m => m.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
