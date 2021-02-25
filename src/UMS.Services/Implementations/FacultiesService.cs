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
    using UMS.Data.Common.Contracts;
    using Data.Models.FacultiesParametersModels;
    using UMS.Data;
    using UMS.Data.Models;
    using UMS.Data.Repositories;

    public class FacultiesService : IFacultiesService
    {
        private const int FacultyPageSize = 10;

        private readonly IDeletableEntityRepository<Faculty> facultyRepository;

        public FacultiesService(IDeletableEntityRepository<Faculty> facultyRepository)
            => this.facultyRepository = facultyRepository;

        public IEnumerable<T> GetAll<T>(int page, int facultiesPerPage = FacultyPageSize)
            => this.facultyRepository.AllAsNoTracking()
             .OrderBy(f => f.Id)
             .Skip((page - 1) * facultiesPerPage)
             .Take(facultiesPerPage)
             .To<T>()
             .ToList();

        public T GetDetailsById<T>(int id)
            => this.facultyRepository.AllAsNoTracking()
                .Where(f => f.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.facultyRepository.All().Count();

        public async Task<bool> Exists(int id)
            => await this.facultyRepository.All().AnyAsync(f => f.Id == id);

        public async Task<int> Create(FacultyCreateParametersModel model)
        {
            var facultyAddress = new FacultyAddress()
            {
                StreetName = model.AddressStreetName,
                District = model.AddressDistrictName,
                Town = model.AddressTownName,
                PostalCode = model.AddressPostalCode,
                Country = model.AddressCountryName,
                Continent = model.Continent,
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

            await this.facultyRepository.AddAsync(faculty);

            await this.facultyRepository.SaveChangesAsync();

            return faculty.Id;
        }

        public async Task<bool> Edit(int id, FacultyEditParametersModel model)
        {
            var faculty = this.facultyRepository.All().FirstOrDefault(f => f.Id == id);

            if (faculty == null)
            {
                return false;
            }

            faculty.Name = model.Name;
            faculty.Description = model.Description;
            faculty.Address.StreetName = model.AddressStreetName;
            faculty.Address.District = model.AddressDistrictName;
            faculty.Address.Town = model.AddressTownName;
            faculty.Address.PostalCode = model.AddressPostalCode;
            faculty.Address.Country = model.AddressCountryName;
            faculty.Address.Continent = model.Continent;
            faculty.Email = model.Email;
            faculty.PhoneNumber = model.PhoneNumber;
            faculty.Fax = model.Fax;

            await this.facultyRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var faculty = this.facultyRepository.All().FirstOrDefault(f => f.Id == id);

            if (faculty == null)
            {
                return false;
            }

            this.facultyRepository.Delete(faculty);

            await this.facultyRepository.SaveChangesAsync();

            return true;
        }
    }
}
