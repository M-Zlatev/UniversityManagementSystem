namespace UMS.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Models;
    using Factories;
    using static SeedingConstants.MajorSeedingConstants;

    public class MajorSeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Majors.Any())
            {
                return;
            }

            var majorFactory = new MajorFactory();
            var majors = majorFactory.CreateEntities();

            // necessary cast for data manipulation in the AddAsyncMajorsInDb method below
            var majorsAfterCast = (List<(string Name, double Duration, int DepartmentId)>)majors;

            await AddAsyncMajorsInDb(dbContext, majorsAfterCast);
        }

        private static async Task AddAsyncMajorsInDb(UmsDbContext dbContext, List<(string Name, double Duration, int DepartmentId)> majorsAfterCast)
        {
            foreach (var major in majorsAfterCast)
            {
                await dbContext.Majors.AddAsync(new Major
                {
                    Name = major.Name,
                    Duration = major.Duration,
                    DepartmentId = major.DepartmentId,
                });
            }
        }
    }
}
