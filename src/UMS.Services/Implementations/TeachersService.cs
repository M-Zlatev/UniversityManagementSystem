namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Services.Contracts;
    using Services.Data.Models.TeachersParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;

    public class TeachersService : ITeachersService
    {
        private const int TeachersPageSize = 20;

        private readonly UmsDbContext data;

        public TeachersService(UmsDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IEnumerable<T> GetAll<T>(int page, int teachersPerPage)
            => this.data
                .Teachers
                .OrderBy(t => t.Id)
                .Skip((page - 1) * TeachersPageSize)
                .Take(TeachersPageSize)
                .To<T>()
                .ToList();

        public T GetDetails<T>(int id)
            => this.data
                .Teachers
                .Where(t => t.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.data.Teachers.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Teachers.AnyAsync(t => t.Id == id);

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

            this.data.Add(teacher);

            await this.data.SaveChangesAsync();

            return teacher.Id;
        }

        public async Task<bool> Edit(int id, TeacherEditParametersModel model)
        {
            var teacher = await this.data.Teachers.FindAsync(id);

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

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var teacher = this.data.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return false;
            }

            this.data.Remove(teacher);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
