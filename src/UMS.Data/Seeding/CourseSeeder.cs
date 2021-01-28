namespace UMS.Data.Seeding
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Models;
    using Factories;
    using static SeedingConstants.FacultySeedingConstants;

    public class CourseSeeder : ISeeder
    {
        public async Task SeedAsync(UmsDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Courses.Any())
            {
                return;
            }

            var courseFactory = new CourseFactory();
            var courses = courseFactory.CreateEntities();

            // necessary cast for data manipulation in the AddAsyncCoursesInDb method below
            var coursesAfterCast = (List<(string Name, int CourseId, int MajorID)>)courses;

            await AddAsyncCoursesInDb(dbContext, coursesAfterCast);
        }

        private static async Task AddAsyncCoursesInDb(UmsDbContext dbContext, List<(string Name, int CourseId, int MajorID)> courses)
        {
            foreach (var currentCourse in courses)
            {

                var course = new Course()
                {
                    Name = currentCourse.Name,
                };

                await dbContext.Courses.AddAsync(course);

                await dbContext.CourseMajors.AddAsync(new CourseMajor
                {
                    Course = course,
                    CourseId = currentCourse.CourseId,
                    MajorId = currentCourse.MajorID,
                });
            }
        }
    }
}
