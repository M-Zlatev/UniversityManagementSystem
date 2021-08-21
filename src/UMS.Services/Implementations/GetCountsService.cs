namespace UMS.Services.Implementations
{
    using System.Linq;

    using Contracts;
    using Models;
    using UMS.Data.Models.Courses;
    using UMS.Data.Models.Departments;
    using UMS.Data.Models.Faculties;
    using UMS.Data.Models.Majors;
    using UMS.Data.Repositories.Contracts;

    public class GetCountsService : IGetCountsService
    {
        private IDeletableEntityRepository<Faculty> facultyRepository;
        private IDeletableEntityRepository<Department> departmentRepository;
        private IDeletableEntityRepository<Major> majorRepository;
        private IDeletableEntityRepository<Course> courseRepository;

        public GetCountsService(
            IDeletableEntityRepository<Faculty> facultyRepository,
            IDeletableEntityRepository<Department> departmentRepository,
            IDeletableEntityRepository<Major> majorRepository,
            IDeletableEntityRepository<Course> courseRepository)
        {
            this.facultyRepository = facultyRepository;
            this.departmentRepository = departmentRepository;
            this.majorRepository = majorRepository;
            this.courseRepository = courseRepository;
        }

        public CountsDto GetUniversityDivisionsCount()
        {
            var data = new CountsDto()
            {
                FacultiesCount = this.facultyRepository.All().Count(),
                DepartmentsCount = this.departmentRepository.All().Count(),
                MajorsCount = this.majorRepository.All().Count(),
                CoursesCount = this.courseRepository.All().Count(),
            };

            return data;
        }
    }
}
