namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using Data.Models.TeachersParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models.Teachers;
    using UMS.Data.Repositories.Contracts;

    public class TeachersService : ITeachersService
    {
        private const int TeachersPageSize = 20;

        private readonly IRepository<TeacherAddress> teacherAddressRepository;
        private readonly IDeletableEntityRepository<Teacher> teacherRepository;

        public TeachersService(
            IDeletableEntityRepository<Teacher> teacherRepository,
            IRepository<TeacherAddress> teacherAddressRepository)
        {
            this.teacherRepository = teacherRepository;
            this.teacherAddressRepository = teacherAddressRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int teachersPerPage)
            => this.teacherRepository.AllAsNoTracking()
                .OrderBy(t => t.Id)
                .Skip((page - 1) * TeachersPageSize)
                .Take(TeachersPageSize)
                .To<T>()
                .ToList();

        public T GetDetailsById<T>(int id)
            => this.teacherRepository.AllAsNoTracking()
                .Where(t => t.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.teacherRepository.All().Count();

        public async Task<bool> Exists(int id)
            => await this.teacherRepository.All().AnyAsync(t => t.Id == id);

        public async Task<int> Create(TeacherCreateParametersModel model)
        {
            var teacherAddress = new TeacherAddress()
            {
                StreetName = model.AddressStreetName,
                District = model.AddressDistrictName,
                Town = model.AddressTownName,
                Country = model.AddressCountryName,
                Continent = model.AddressContinentName,
            };

            var teacher = new Teacher()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Gender = model.Gender,
                Address = teacherAddress,
                AcademicRank = model.AcademicRank,
                AcademicDegree = model.AcademicDegree,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                ImageUrl = model.ImageUrl,
            };

            await this.teacherRepository.AddAsync(teacher);
            await this.teacherRepository.SaveChangesAsync();

            return teacher.Id;
        }

        public async Task<bool> Edit(int id, TeacherEditParametersModel model)
        {
            var teacher = this.teacherRepository.All().FirstOrDefault(m => m.Id == id);
            var teacherAddress = this.teacherAddressRepository.All().Where(t => t.TeacherId == id).FirstOrDefault();

            if (teacher == null)
            {
                return false;
            }

            teacher.FirstName = model.FirstName;
            teacher.MiddleName = model.MiddleName;
            teacher.LastName = model.LastName;
            teacher.Gender = model.Gender;

            teacherAddress.StreetName = model.AddressStreetName;
            teacherAddress.Town = model.AddressTownName;
            teacherAddress.District = model.AddressDistrictName;
            teacherAddress.Country = model.AddressCountryName;
            teacherAddress.Continent = model.AddressContinentName;

            teacher.AcademicDegree = model.AcademicDegree;
            teacher.AcademicRank = model.AcademicRank;
            teacher.PhoneNumber = model.PhoneNumber;
            teacher.Email = model.Email;
            teacher.ImageUrl = model.ImageUrl;

            await this.teacherRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var teacher = this.teacherRepository.All().FirstOrDefault(m => m.Id == id);

            if (teacher == null)
            {
                return false;
            }

            this.teacherRepository.Delete(teacher);

            await this.teacherRepository.SaveChangesAsync();

            return true;
        }
    }
}
