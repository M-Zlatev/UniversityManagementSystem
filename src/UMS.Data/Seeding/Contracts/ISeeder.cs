namespace UMS.Data.Seeding.Contracts
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider);
    }
}
