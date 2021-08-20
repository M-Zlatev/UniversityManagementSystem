namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Services.Mapping.Infrastructure;
    using UMS.Data.Models.Departments;
    using UMS.Data.Models.Majors;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Majors;

    public class MajorsService : IMajorsService
    {
        private const int MajorPageSize = 10;

        private readonly IDeletableEntityRepository<Major> majorRepository;
        private readonly IDeletableEntityRepository<Department> departmentRepository;

        public MajorsService(
            IDeletableEntityRepository<Major> majorRepository,
            IDeletableEntityRepository<Department> departmentRepository)
        {
            this.majorRepository = majorRepository;
            this.departmentRepository = departmentRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int majorsPerPage = MajorPageSize)
            => this.majorRepository.AllAsNoTracking()
             .OrderBy(m => m.Id)
             .Skip((page - 1) * majorsPerPage)
             .Take(majorsPerPage)
             .To<T>()
             .ToList();

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
             => this.departmentRepository.AllAsNoTracking()
             .Select(c => new
             {
                 c.Id,
                 c.Name,
             }).ToList()
             .Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));

        public T GetDetailsById<T>(int id)
            => this.majorRepository.AllAsNoTracking()
                .Where(m => m.Id == id)
                .To<T>()
                .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.majorRepository.All().AnyAsync(m => m.Id == id);

        public int GetCount()
            => this.majorRepository.All().Count();

        public async Task<int> CreateAsync(CreateMajorInputForm createForm)
        {
            var departmentId = this.departmentRepository.All()
                .Where(d => d.Id == createForm.DepartmentId)
                .Select(d => d.Id)
                .FirstOrDefault();

            var major = new Major
            {
                Name = createForm.Name,
                Description = createForm.Description,
                MajorType = createForm.MajorType,
                Duration = createForm.Duration,
                DepartmentId = departmentId,
            };

            await this.majorRepository.AddAsync(major);

            await this.majorRepository.SaveChangesAsync();

            return major.Id;
        }

        public async Task<bool> EditAsync(int id, EditMajorInputForm editForm)
        {
            var major = this.majorRepository.All().FirstOrDefault(m => m.Id == id);

            if (major == null)
            {
                return false;
            }

            var departmentId = this.departmentRepository.All()
                .Where(d => d.Id == editForm.DepartmentId)
                .Select(d => d.Id)
                .FirstOrDefault();

            major.Name = editForm.Name;
            major.Description = editForm.Description;
            major.MajorType = editForm.MajorType;
            major.Duration = editForm.Duration;
            major.DepartmentId = departmentId;

            await this.majorRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var major = this.majorRepository.All().FirstOrDefault(m => m.Id == id);

            if (major == null)
            {
                return false;
            }

            this.majorRepository.Delete(major);

            await this.majorRepository.SaveChangesAsync();

            return true;
        }
    }
}
