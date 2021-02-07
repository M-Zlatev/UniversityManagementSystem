namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Data;
    using Data.Common.Enumerations;
    using Data.Models;
    using Services.Contracts;

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

        public async Task<int> Create(string firstName, string middleName, string lastName, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string phoneNumber, string email, string imageUrl, string userId)
        {
            var teacherAddress = new TeacherAddress()
            {
                StreetName = streetName,
                Town = streetName,
                District = districtName,
                Country = townName,
            };

            var teacher = new Teacher()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Gender = gender,
                Address = teacherAddress,
                PhoneNumber = phoneNumber,
                Email = email,
                ImageUrl = imageUrl,
            };

            this.data.Add(teacher);

            await this.data.SaveChangesAsync();

            return teacher.Id;
        }

        public async Task<bool> Edit(int id, string firstName, string middleName, string lastName, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string phoneNumber, string email, string imageUrl)
        {
            var teacher = await this.data.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return false;
            }

            teacher.FirstName = firstName;
            teacher.MiddleName = middleName;
            teacher.LastName = lastName;
            teacher.Gender = gender;
            teacher.Address.StreetName = streetName;
            teacher.Address.Town = townName;
            teacher.Address.District = districtName;
            teacher.Address.Country = countryName;
            teacher.PhoneNumber = phoneNumber;
            teacher.Email = email;
            teacher.ImageUrl = imageUrl;

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
