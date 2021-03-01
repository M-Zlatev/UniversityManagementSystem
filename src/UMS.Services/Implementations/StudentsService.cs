namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using Data.Models.StudentsParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Data.Repositories;

    public class StudentsService : IStudentsService
    {
        private const int StudentsPageSize = 20;

        private readonly IDeletableEntityRepository<Student> studentRepository;
        private readonly IRepository<StudentMajor> studentMajorsRepository;
        private readonly IDeletableEntityRepository<Major> majorRepository;

        public StudentsService(
            IDeletableEntityRepository<Student> studentRepository,
            IRepository<StudentMajor> studentMajorsRepository,
            IDeletableEntityRepository<Major> majorRepository)
        {
            this.studentRepository = studentRepository;
            this.studentMajorsRepository = studentMajorsRepository;
            this.majorRepository = majorRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int studentsPerPage)
            => this.studentRepository.AllAsNoTracking()
                .OrderBy(s => s.Id)
                .Skip((page - 1) * StudentsPageSize)
                .Take(StudentsPageSize)
                .To<T>()
                .ToList();

        public T GetDetailsById<T>(int id)
            => this.studentRepository.AllAsNoTracking()
                .Where(s => s.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.studentRepository.All().Count();

        public async Task<bool> Exists(int id)
            => await this.studentRepository.All().AnyAsync(d => d.Id == id);

        public async Task<int> Create(StudentCreateParametersModel model)
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

        public async Task<bool> Edit(int id, StudentEditParametersModel model)
        {
            var student = this.studentRepository.All().FirstOrDefault(st => st.Id == id);

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
            student.Address.StreetName = model.AddressStreetName;
            student.Address.Town = model.AddressTownName;
            student.Address.District = model.AddressDistrictName;
            student.Address.Country = model.AddressCountryName;
            student.PhoneNumber = model.PhoneNumber;
            student.Email = model.Email;
            student.ImageUrl = model.ImageUrl;
            student.HasScholarship = model.HasScholarship;

            await this.studentRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
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

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
            => this.majorRepository.AllAsNoTracking()
            .Select(c => new
            {
                c.Id,
                c.Name,
            }).ToList()
            .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
    }
}
