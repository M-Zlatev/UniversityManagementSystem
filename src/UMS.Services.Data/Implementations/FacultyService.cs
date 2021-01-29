namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Models.Faculties;
    using UMS.Data;
    using UMS.Data.Models;

    public class FacultyService : IFacultyService
    {
        private const int FacultyPageSize = 10;

        private readonly UmsDbContext data;

        public FacultyService(UmsDbContext data)
            => this.data = data;

        public async Task<IEnumerable<FacultyListingServiceModel>> All(int page)
            => await this.data
                .Faculties
                .Skip((page - 1) * FacultyPageSize)
                .Take(FacultyPageSize)
                .Select(f => new FacultyListingServiceModel
                {
                    Id = f.Id,
                    FacultyName = f.Name,
                    Description = f.Description,
                })
                .ToListAsync();

        public async Task<FacultyDetailsServiceModel> Details(int id)
            => await this.data.Faculties
                .Where(f => f.Id == id)
                .Select(f => new FacultyDetailsServiceModel
                {
                    Id = f.Id,
                    Name = f.Name,
                    Description = f.Description,
                    AddressStreetName = f.Address.StreetName,
                    AddressTownName = f.Address.Town,
                    AddressCountryName = f.Address.Country,
                    Email = f.Email,
                    PhoneNumber = f.PhoneNumber,
                    Fax = f.Fax,
                })
                .FirstOrDefaultAsync();

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
