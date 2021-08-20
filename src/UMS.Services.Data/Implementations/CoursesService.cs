namespace UMS.Services.Data.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Services.Mapping.Infrastructure;
    using UMS.Data.Models.Courses;
    using UMS.Data.Models.Majors;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Courses;

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

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
            => this.majorsRepository.AllAsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        public T GetDetailsById<T>(int id)
            => this.coursesRepository.AllAsNoTracking()
            .Where(c => c.Id == id)
            .To<T>()
            .FirstOrDefault();

        public int GetCount()
            => this.coursesRepository.All().Count();

        public async Task<bool> Exists(int id)
            => await this.coursesRepository.All().AnyAsync(c => c.Id == id);

        public async Task<int> CreateAsync(CreateCourseInputForm form)
        {
            var major = this.majorsRepository.All()
                .Where(m => m.Id == form.MajorId)
                .FirstOrDefault();

            var course = new Course()
            {
                Name = form.Name,
                Description = form.Description,
                StartDate = form.StartDate,
                EndDate = form.EndDate,
                Price = form.Price,
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

        public async Task<bool> EditAsync(int id, EditCourseInputForm form)
        {
            var course = this.coursesRepository.All().FirstOrDefault(c => c.Id == id);

            if (course == null)
            {
                return false;
            }

            course.Name = form.Name;
            course.Description = form.Description;
            course.StartDate = form.StartDate;
            course.EndDate = form.EndDate;
            course.Price = form.Price;

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
    }
}
