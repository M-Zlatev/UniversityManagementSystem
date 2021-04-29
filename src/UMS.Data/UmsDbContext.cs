namespace UMS.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    using Common.Contracts;
    using Infrastructure;
    using Models.Courses;
    using Models.Departments;
    using Models.Forum;
    using Models.Homeworks;
    using Models.Majors;
    using Models.Resources;
    using Models.Faculties;
    using Models.UserDefinedPrincipal;

    public class UmsDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public UmsDbContext(DbContextOptions<UmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<FacultyAddress> FacultyAddresses { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseMajor> CourseMajors { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Vote> Votes { get; set; }

        public DbSet<ApplicationUserAddress> ApplicationUserAddresses { get; set; }

        public DbSet<ApplicationUserMajor> ApplicationUserMajors { get; set; }

        public DbSet<ApplicationUserCourse> ApplicationUserCourses { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            // Applies configurations
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            EntityIndexesConfiguration.Configure(builder);
        }

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
