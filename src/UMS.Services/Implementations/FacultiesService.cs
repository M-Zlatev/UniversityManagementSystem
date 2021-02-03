namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Common.Mapping;
    using UMS.Data;
    using UMS.Data.Models;

    public class FacultiesService : IFacultiesService
    {
        private const int FacultyPageSize = 10;

        private readonly UmsDbContext data;

        public FacultiesService(UmsDbContext data)
        {
            this.data = data;
        }

        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage = FacultyPageSize)
            => this.data
             .Faculties
             .OrderBy(f => f.Id)
             .Skip((page - 1) * facultiesPerPage)
             .Take(facultiesPerPage)
             .To<T>()
             .ToList();

        public T GetDetails<T>(int id)
            => this.data
                .Faculties
                .Where(f => f.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.data.Faculties.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Faculties.AnyAsync(f => f.Id == id);

        public async Task<int> Create(string name, string description, string addressStreetName, string addressTownName, string addressCountryName, string email, string phoneNumber, string fax, string userId)
        {
            var facultyAddress = new FacultyAddress()
            {
                StreetName = addressStreetName,
                Town = addressTownName,
                Country = addressCountryName,
            };

            var faculty = new Faculty
            {
                Name = name,
                Description = description,
                Address = facultyAddress,
                Email = email,
                PhoneNumber = phoneNumber,
                Fax = fax,
            };

            this.data.Add(faculty);

            await this.data.SaveChangesAsync();

            return faculty.Id;
        }

        public async Task<bool> Edit(int id, string name, string description, string streetName, string townName, string countryName, string email, string phoneNumber, string fax)
        {
            var faculty = await this.data.Faculties.FindAsync(id);

            if (faculty == null)
            {
                return false;
            }

            faculty.Name = name;
            faculty.Description = description;
            faculty.Address.StreetName = streetName;
            faculty.Address.Town = townName;
            faculty.Address.Country = countryName;
            faculty.Email = email;
            faculty.PhoneNumber = phoneNumber;
            faculty.Fax = fax;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var faculty = this.data.Faculties.FindAsync(id);

            if (faculty == null)
            {
                return false;
            }

            this.data.Remove(faculty);

            await this.data.SaveChangesAsync();

            return true;
        }
    }
}
