namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Services.Mapping.Infrastructure;
    using UMS.Data.Models.Faculties;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Faculties;

    public class FacultiesService : IFacultiesService
    {
        private const int FacultyPageSize = 10;

        private readonly IRepository<FacultyAddress> facultyAddressRepository;
        private readonly IDeletableEntityRepository<Faculty> facultyRepository;

        // this constructor was created for easier mocking and testing
        public FacultiesService(IDeletableEntityRepository<Faculty> facultyRepository)
        {
            this.facultyRepository = facultyRepository;
        }

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

        public async Task<int> CreateAsync(CreateFacultyInputForm createForm)
        {
            var facultyAddress = new FacultyAddress()
            {
                StreetName = createForm.AddressStreetName,
                District = createForm.AddressDistrictName,
                Town = createForm.AddressTownName,
                PostalCode = createForm.AddressPostalCode,
                Country = createForm.AddressCountryName,
                Continent = createForm.AddressContinentName,
            };

            var faculty = new Faculty
            {
                Name = createForm.Name,
                Description = createForm.Description,
                Address = facultyAddress,
                Email = createForm.Email,
                PhoneNumber = createForm.PhoneNumber,
                Fax = createForm.Fax,
            };

            await this.facultyRepository.AddAsync(faculty);

            await this.facultyRepository.SaveChangesAsync();

            return faculty.Id;
        }

        public async Task<bool> EditAsync(int id, EditFacultyInputForm editForm)
        {
            var faculty = this.facultyRepository.All().FirstOrDefault(f => f.Id == id);
            var facultyAddress = this.facultyAddressRepository.All()
                .Where(f => f.FacultyId == id)
                .FirstOrDefault();

            if (faculty == null)
            {
                return false;
            }

            faculty.Name = editForm.Name;
            faculty.Description = editForm.Description;

            facultyAddress.StreetName = editForm.AddressStreetName;
            facultyAddress.District = editForm.AddressDistrictName;
            facultyAddress.Town = editForm.AddressTownName;
            facultyAddress.PostalCode = editForm.AddressPostalCode;
            facultyAddress.Country = editForm.AddressCountryName;
            facultyAddress.Continent = editForm.AddressContinentName;

            faculty.Email = editForm.Email;
            faculty.PhoneNumber = editForm.PhoneNumber;
            faculty.Fax = editForm.Fax;

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
