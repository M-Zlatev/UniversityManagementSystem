namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Services.Contracts;
    using Services.Data.Models.StudentsParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;

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

        public async Task<int> Create(StudentCreateParametersModel model)
        {
            var major = this.data
                        .Majors
                        .Where(m => m.Name == model.MajorName)
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

        public async Task<bool> Edit(int id, StudentEditParametersModel model)
        {
            var student = await this.data.Students.FindAsync(id);

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
