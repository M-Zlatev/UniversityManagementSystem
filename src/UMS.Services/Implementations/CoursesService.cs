namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using Data.Models.CoursesParametersModels;
    using UMS.Data;
    using UMS.Data.Models;
    using UMS.Data.Repositories;

    public class CoursesService : ICoursesService
    {
        private const int CoursesPageSize = 20;

        private readonly IDeletableEntityRepository<Course> coursesRepository;
        private readonly IDeletableEntityRepository<Major> majorsRepository;
        private readonly IRepository<CourseMajor> courseMajorsRepository;

        public CoursesService(
            IDeletableEntityRepository<Course> coursesRepository,
            IDeletableEntityRepository<Major> majorsRepository,
            IRepository<CourseMajor> courseMajorsRepository)
        {
            this.coursesRepository = coursesRepository;
            this.majorsRepository = majorsRepository;
            this.courseMajorsRepository = courseMajorsRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int coursesPerPage = CoursesPageSize)
            => this.coursesRepository.AllAsNoTracking()
            .OrderBy(c => c.Id)
            .Skip((page - 1) * coursesPerPage)
            .Take(coursesPerPage)
            .To<T>()
            .ToList();

        public T GetDetailsById<T>(int id)
            => this.coursesRepository.AllAsNoTracking()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task<int> CreateAsync(CourseCreateParametersModel model)
        {
            CheckIfUserEnterDate(model.StartDate, model.EndDate);

            var major = this.majorsRepository.AllAsNoTracking()
                .Where(m => m.Id == model.MajorId)
                .FirstOrDefault();

            var course = new Course()
            {
                Name = model.Name,
                Description = model.Description,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Price = model.Price,
            };

            await this.coursesRepository.AddAsync(course);
            await this.coursesRepository.SaveChangesAsync();

            var courseMajor = new CourseMajor()
            {
                Course = course,
                CourseId = course.Id,
                Major = major,
                MajorId = major.Id,
            };

            await this.courseMajorsRepository.AddAsync(courseMajor);
            await this.courseMajorsRepository.SaveChangesAsync();

            return course.Id;
        }

        public async Task<bool> EditAsync(int id, CourseEditParametersModel model)
        {
            var course = this.coursesRepository.All().FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return false;
            }

            CheckIfUserEnterDate(model.StartDate, model.EndDate);

            course.Name = model.Name;
            course.Description = model.Description;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.Price = model.Price;

            await this.coursesRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var course = this.coursesRepository.All().FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return false;
            }

            this.coursesRepository.Delete(course);

            await this.coursesRepository.SaveChangesAsync();

            return true;
        }

        public int GetCount()
            => this.coursesRepository.All().Count();

        public async Task<bool> Exists(int id)
            => await this.coursesRepository.All().AnyAsync(c => c.Id == id);

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
            => this.majorsRepository.AllAsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        private static void CheckIfUserEnterDate(DateTime startDate, DateTime endDate)
        {
            if (startDate == default)
            {
                startDate = DateTime.UtcNow;
            }

            if (endDate == default)
            {
                startDate = DateTime.UtcNow.AddMonths(6);
            }
        }
    }
}
