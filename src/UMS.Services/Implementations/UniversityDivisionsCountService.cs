namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using Dtos;
    using UMS.Data.Models.Courses;
    using UMS.Data.Models.Departments;
    using UMS.Data.Models.Faculties;
    using UMS.Data.Models.Majors;
    using UMS.Data.Repositories.Contracts;

    public class UniversityDivisionsCountService : IUniversityDivisionsCountService
    {
        private IDeletableEntityRepository<Faculty> facultyRepository;
        private IDeletableEntityRepository<Department> departmentRepository;
        private IDeletableEntityRepository<Major> majorRepository;
        private IDeletableEntityRepository<Course> courseRepository;

        public UniversityDivisionsCountService(
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

        public UniversityDivisionsCount GetUniversityDivisionsCount()
        {
            var data = new UniversityDivisionsCount()
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
