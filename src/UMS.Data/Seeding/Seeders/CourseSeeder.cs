namespace UMS.Data.Seeders.Seeding
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Data.Seeding.Contracts;
    using Models;
    using UMS.Data.Models.Courses;
    using UMS.Data.Seeding.Factories;

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
            var coursesAfterCast = (List<(string Name, decimal Price, int MajorId)>)courses;

            await AddAsyncCoursesInDb(dbContext, coursesAfterCast);
        }

        private static async Task AddAsyncCoursesInDb(UmsDbContext dbContext, List<(string Name, decimal Price, int MajorId)> courses)
        {
            foreach (var currentCourse in courses)
            {
                var course = new Course()
                {
                    Name = currentCourse.Name,
                    Price = currentCourse.Price,
                };

                await dbContext.Courses.AddAsync(course);

                var major = dbContext.Majors
                    .Where(m => m.Id == currentCourse.MajorId)
                    .FirstOrDefault();

                var currentCourseId = course.Id;

                await dbContext.CourseMajors.AddAsync(new CourseMajor
                {
                    Major = major,
                    MajorId = currentCourse.MajorId,
                    Course = course,
                    CourseId = currentCourseId,
                });
            }
        }
    }
}
