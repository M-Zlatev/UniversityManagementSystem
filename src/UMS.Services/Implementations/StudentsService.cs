namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data.Models.StudentsParametersModels;
    using Mapping.Infrastructure;
    using UMS.Data.Models.Majors;
    using UMS.Data.Models.Students;
    using UMS.Data.Repositories.Contracts;

    public class StudentsService : IStudentsService
    {
        private const int StudentsPageSize = 20;

        private readonly IDeletableEntityRepository<Student> studentRepository;
        private readonly IRepository<StudentAddress> studentAddressRepository;
        private readonly IDeletableEntityRepository<Major> majorRepository;
        private readonly IRepository<StudentMajor> studentMajorsRepository;

        public StudentsService(
            IDeletableEntityRepository<Student> studentRepository,
            IRepository<StudentAddress> studentAddressRepository,
            IDeletableEntityRepository<Major> majorRepository,
            IRepository<StudentMajor> studentMajorsRepository)
        {
            this.studentRepository = studentRepository;
            this.studentAddressRepository = studentAddressRepository;
            this.majorRepository = majorRepository;
            this.studentMajorsRepository = studentMajorsRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int studentsPerPage)
            => this.studentRepository.AllAsNoTracking()
                .OrderBy(s => s.Id)
                .Skip((page - 1) * StudentsPageSize)
                .Take(StudentsPageSize)
                .To<T>()
                .ToList();

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
            => this.majorRepository.AllAsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        public T GetDetailsById<T>(int id)
            => this.studentRepository.AllAsNoTracking()
                .Where(s => s.Id == id)
                .To<T>()
                .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.studentRepository.All().AnyAsync(d => d.Id == id);

        public int GetCount()
            => this.studentRepository.All().Count();

        public async Task<int> CreateAsync(StudentCreateParametersModel model)
        {
            var major = this.majorRepository.All()
                        .Where(m => m.Id == model.MajorId)
                        .FirstOrDefault();

            var studentAddress = new StudentAddress()
            {
                StreetName = model.AddressStreetName,
                Town = model.AddressTownName,
                District = model.AddressDistrictName,
                Country = model.AddressCountryName,
                Continent = model.AddressContinentName,
            };

            var student = new Student()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                UniformCivilNumber = model.UniformCivilNumber,
                DateofBirth = model.DateOfBirth,
                Gender = model.Gender,
                Address = studentAddress,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                ImageUrl = model.ImageUrl,
                HasScholarship = model.HasScholarship,
            };

            await this.studentRepository.AddAsync(student);

            if (major != null)
            {
                var studentMajor = new StudentMajor()
                {
                    Student = student,
                    StudentId = student.Id,
                    Major = major,
                    MajorId = major.Id,
                };

                await this.studentMajorsRepository.AddAsync(studentMajor);
            }

            await this.studentRepository.SaveChangesAsync();

            return student.Id;
        }

        public async Task<bool> EditAsync(int id, StudentEditParametersModel model)
        {
            var student = this.studentRepository.All().FirstOrDefault(st => st.Id == id);
            var studentAddress = this.studentAddressRepository.All().Where(st => st.StudentId == id).FirstOrDefault();

            if (student == null)
            {
                return false;
            }

            student.FirstName = model.FirstName;
            student.MiddleName = model.MiddleName;
            student.LastName = model.LastName;
            student.UniformCivilNumber = model.UniformCivilNumber;
            student.DateofBirth = model.DateOfBirth;
            student.Gender = model.Gender;

            studentAddress.StreetName = model.AddressStreetName;
            studentAddress.District = model.AddressDistrictName;
            studentAddress.Town = model.AddressTownName;
            studentAddress.Country = model.AddressCountryName;
            studentAddress.Continent = model.AddressContinentName;

            student.PhoneNumber = model.PhoneNumber;
            student.Email = model.Email;
            student.ImageUrl = model.ImageUrl;
            student.HasScholarship = model.HasScholarship;

            await this.studentRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var student = this.studentRepository.All().FirstOrDefault(st => st.Id == id);

            if (student == null)
            {
                return false;
            }

            this.studentRepository.Delete(student);

            await this.studentRepository.SaveChangesAsync();

            return true;
        }
    }
}
