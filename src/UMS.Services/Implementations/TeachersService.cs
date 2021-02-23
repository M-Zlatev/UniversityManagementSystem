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
    using UMS.Data.Models;
    using UMS.Data.Repositories;

    public class TeachersService : ITeachersService
    {
        private const int TeachersPageSize = 20;

        private readonly IDeletableEntityRepository<Teacher> teacherRepository;

        public TeachersService(IDeletableEntityRepository<Teacher> teacherRepository)
            => this.teacherRepository = teacherRepository;

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
                Town = model.AddressTownName,
                District = model.AddressDistrictName,
                Country = model.AddressCountryName,
            };

            var teacher = new Teacher()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                Gender = model.Gender,
                Address = teacherAddress,
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

            if (teacher == null)
            {
                return false;
            }

            teacher.FirstName = model.FirstName;
            teacher.MiddleName = model.MiddleName;
            teacher.LastName = model.LastName;
            teacher.Gender = model.Gender;
            teacher.Address.StreetName = model.AddressStreetName;
            teacher.Address.Town = model.AddressTownName;
            teacher.Address.District = model.AddressDistrictName;
            teacher.Address.Country = model.AddressCountryName;
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
