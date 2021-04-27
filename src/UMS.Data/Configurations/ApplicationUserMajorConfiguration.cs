namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.UserDefinedPrincipal;

    public class ApplicationUserMajorConfiguration : IEntityTypeConfiguration<ApplicationUserMajor>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserMajor> appUserMajor)
        {
            appUserMajor.HasKey(um => new { um.UserId, um.MajorId });

            appUserMajor
                .HasOne(um => um.User)
                .WithMany(u => u.Majors)
                .HasForeignKey(um => um.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            appUserMajor
                .HasOne(u => u.Major)
                .WithMany(m => m.User)
                .HasForeignKey(um => um.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
