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
    using Data.Models.FacultiesParametersModels;
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

        public T GetDetailsById<T>(int id)
            => this.data
                .Faculties
                .Where(f => f.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.data.Faculties.Count();

        public async Task<bool> Exists(int id)
            => await this.data.Faculties.AnyAsync(f => f.Id == id);

        public async Task<int> Create(FacultyCreateParametersModel model)
        {
            var facultyAddress = new FacultyAddress()
            {
                StreetName = model.StreetName,
                Town = model.TownName,
                Country = model.CountryName,
            };

            var faculty = new Faculty
            {
                Name = model.Name,
                Description = model.Description,
                Address = facultyAddress,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Fax = model.Fax,
            };

            this.data.Add(faculty);

            await this.data.SaveChangesAsync();

            return faculty.Id;
        }

        public async Task<bool> Edit(int id, FacultyEditParametersModel model)
        {
            var faculty = await this.data.Faculties.FindAsync(id);

            if (faculty == null)
            {
                return false;
            }

            faculty.Name = model.Name;
            faculty.Description = model.Description;
            faculty.Address.StreetName = model.StreetName;
            faculty.Address.Town = model.TownName;
            faculty.Address.Country = model.CountryName;
            faculty.Email = model.Email;
            faculty.PhoneNumber = model.PhoneNumber;
            faculty.Fax = model.Fax;

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
