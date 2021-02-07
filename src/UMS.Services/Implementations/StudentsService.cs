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

    public class StudentsService : IStudentsService
    {
        private const int StudentsPageSize = 20;

        private readonly UmsDbContext data;

        public StudentsService(UmsDbContext dbContext)
        {
            this.data = dbContext;
        }

        public IEnumerable<T> GetAll<T>(int page, int studentsPerPage)
            => this.data
                .Students
                .OrderBy(s => s.Id)
                .Skip((page - 1) * StudentsPageSize)
                .Take(StudentsPageSize)
                .To<T>()
                .ToList();

        public T GetDetails<T>(int id)
            => this.data
                .Students
                .Where(s => s.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.data.Students.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Students.AnyAsync(s => s.Id == id);

        public async Task<int> Create(string firstName, string middleName, string lastName, int uniformCivilNumber, DateTime dateOfBirth, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string majorName, string phoneNumber, string email, string imageUrl, bool hasScholarship, string userId)
        {
            var major = this.data
                        .Majors
                        .Where(m => m.Name == majorName)
                        .FirstOrDefault();

            var studentAddress = new StudentAddress()
            {
                StreetName = streetName,
                Town = streetName,
                District = districtName,
                Country = townName,
            };

            var student = new Student()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                UniformCivilNumber = uniformCivilNumber,
                DateofBirth = dateOfBirth,
                Gender = gender,
                Address = studentAddress,
                PhoneNumber = phoneNumber,
                Email = email,
                ImageUrl = imageUrl,
                HasScholarship = hasScholarship,
            };

            this.data.Add(student);

            if (major != null)
            {
                var studentMajor = new StudentMajor()
                {
                    Student = student,
                    StudentId = student.Id,
                    Major = major,
                    MajorId = major.Id,
                };

                this.data.Add(studentMajor);
            }

            await this.data.SaveChangesAsync();

            return student.Id;
        }

        public async Task<bool> Edit(int id, string firstName, string middleName, string lastName, int uniformCivilNumber, DateTime dateOfBirth, Gender gender, string streetName, string townName, string districtName, string countryName, string continentName, string major, string phoneNumber, string email, string imageUrl, bool hasScholarship)
        {
            var student = await this.data.Students.FindAsync(id);

            if (student == null)
            {
                return false;
            }

            student.FirstName = firstName;
            student.MiddleName = middleName;
            student.LastName = lastName;
            student.UniformCivilNumber = uniformCivilNumber;
            student.DateofBirth = dateOfBirth;
            student.Gender = gender;
            student.Address.StreetName = streetName;
            student.Address.Town = townName;
            student.Address.District = districtName;
            student.Address.Country = countryName;
            student.PhoneNumber = phoneNumber;
            student.Email = email;
            student.ImageUrl = imageUrl;
            student.HasScholarship = hasScholarship;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var student = this.data.Students.FindAsync(id);

            if (student == null)
            {
                return false;
            }

            this.data.Remove(student);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
