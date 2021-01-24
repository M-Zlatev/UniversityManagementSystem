namespace UMS.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
