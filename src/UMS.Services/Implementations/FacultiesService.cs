namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data.Models.FacultiesParametersModels;
    using Services.Mapping.Infrastructure;
    using UMS.Data.Models.Faculties;
    using UMS.Data.Repositories.Contracts;

    public class FacultiesService : IFacultiesService
    {
        private const int FacultyPageSize = 10;

        private readonly IRepository<FacultyAddress> facultyAddressRepository;
        private readonly IDeletableEntityRepository<Faculty> facultyRepository;

        public FacultiesService(
            IDeletableEntityRepository<Faculty> facultyRepository,
            IRepository<FacultyAddress> facultyAddressRepository)
        {
            this.facultyRepository = facultyRepository;
            this.facultyAddressRepository = facultyAddressRepository;
        }

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

        public async Task<bool> Exists(int id)
            => await this.facultyRepository.All().AnyAsync(f => f.Id == id);

        public int GetCount()
            => this.facultyRepository.All().Count();

        public async Task<int> CreateAsync(FacultyCreateParametersModel model)
        {
            var facultyAddress = new FacultyAddress()
            {
                StreetName = model.AddressStreetName,
                District = model.AddressDistrictName,
                Town = model.AddressTownName,
                PostalCode = model.AddressPostalCode,
                Country = model.AddressCountryName,
                Continent = model.AddressContinentName,
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

        public async Task<bool> EditAsync(int id, FacultyEditParametersModel model)
        {
            var faculty = this.facultyRepository.All().FirstOrDefault(f => f.Id == id);
            var facultyAddress = this.facultyAddressRepository.All()
                .Where(f => f.FacultyId == id)
                .FirstOrDefault();

            if (faculty == null)
            {
                return false;
            }

            faculty.Name = model.Name;
            faculty.Description = model.Description;

            facultyAddress.StreetName = model.AddressStreetName;
            facultyAddress.District = model.AddressDistrictName;
            facultyAddress.Town = model.AddressTownName;
            facultyAddress.PostalCode = model.AddressPostalCode;
            facultyAddress.Country = model.AddressCountryName;
            facultyAddress.Continent = model.AddressContinentName;

            faculty.Email = model.Email;
            faculty.PhoneNumber = model.PhoneNumber;
            faculty.Fax = model.Fax;

            await this.facultyRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
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
