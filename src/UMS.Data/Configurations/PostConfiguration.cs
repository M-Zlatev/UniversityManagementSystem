namespace UMS.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    using Models.Forum;

    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> post)
        {
            post
             .HasMany(p => p.Comments)
             .WithOne(c => c.Post)
             .HasForeignKey(c => c.PostId)
             .OnDelete(DeleteBehavior.Restrict);

            post
             .HasMany(p => p.Votes)
             .WithOne(v => v.Post)
             .HasForeignKey(v => v.PostId)
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
