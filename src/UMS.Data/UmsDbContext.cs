namespace UMS.Data
{
    using System.Reflection;

    using Microsoft.EntityFrameworkCore;

    using Models;

    public class UmsDbContext : DbContext
    {
        public UmsDbContext(DbContextOptions<UmsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Major> Majors { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
