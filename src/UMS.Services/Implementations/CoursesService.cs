namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using Data;
    using Data.Models;

    public class CoursesService : ICoursesService
    {
        private const int CoursesPageSize = 20;

        private readonly UmsDbContext data;

        public CoursesService(UmsDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IEnumerable<T> GetAll<T>(int page, int coursesPerPage = CoursesPageSize)
            => this.data
            .Courses
            .OrderBy(c => c.Id)
            .Skip((page - 1) * coursesPerPage)
            .Take(coursesPerPage)
            .To<T>()
            .ToList();

        public T GetDetails<T>(int id)
            => this.data
            .Courses
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefault();

        public int GetCount()
            => this.data.Courses.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Courses.AnyAsync(c => c.Id == id);

        public async Task<int> Create(string name, string description, DateTime startDate, DateTime endDate, decimal price, string belongsToMajor, string userId)
        {
            CheckDate(startDate, endDate);

            var major = this.data
                .Majors
                .Where(m => m.Name == belongsToMajor)
                .FirstOrDefault();

            var course = new Course()
            {
                Name = name,
                Description = description,
                StartDate = startDate,
                EndDate = endDate,
                Price = price,
            };

            var courseMajor = new CourseMajor()
            {
                Course = course,
                CourseId = course.Id,
                Major = major,
                MajorId = major.Id,
            };

            this.data.Courses.Add(course);
            this.data.CourseMajors.Add(courseMajor);

            await this.data.SaveChangesAsync();

            return course.Id;
        }

        public async Task<bool> Edit(int id, string name, string description, DateTime startDate, DateTime endDate, decimal price, string belongsToMajor)
        {
            var course = await this.data.Courses.FindAsync(id);

            if (course == null)
            {
                return false;
            }

            CheckDate(startDate, endDate);

            course.Name = name;
            course.Description = description;
            course.StartDate = startDate;
            course.EndDate = endDate;
            course.Price = price;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var course = this.data.Courses.FindAsync(id);

            if (course == null)
            {
                return false;
            }

            this.data.Remove(course);

            await this.data.SaveChangesAsync();

            return true;
        }

        private static void CheckDate(DateTime startDate, DateTime endDate)
        {
            if (startDate == null)
            {
                startDate = DateTime.UtcNow;
            }

            if (endDate == null)
            {
                startDate = DateTime.UtcNow.AddMonths(6);
            }
        }
    }
}
