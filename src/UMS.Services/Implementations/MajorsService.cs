namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using Data.Models.MajorsParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Data.Repositories;

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

        public T GetDetailsById<T>(int id)
            => this.majorRepository.AllAsNoTracking()
                .Where(m => m.Id == id)
                .To<T>()
                .FirstOrDefault();

        public int GetCount()
            => this.majorRepository.All().Count();

        public async Task<bool> Exists(int id)
            => await this.majorRepository.All().AnyAsync(m => m.Id == id);

        public async Task<int> Create(MajorCreateParametersModel model)
        {
            var departmentId = this.departmentRepository.AllAsNoTracking()
                .Where(d => d.Name == model.BelongsToDepartment)
                .Select(d => d.Id)
                .FirstOrDefault();

            var major = new Major
            {
                Name = model.Name,
                Description = model.Description,
                MajorType = model.MajorType,
                Duration = model.Duration,
                DepartmentId = departmentId,
            };

            await this.majorRepository.AddAsync(major);

            await this.majorRepository.SaveChangesAsync();

            return major.Id;
        }

        public async Task<bool> Edit(int id, MajorEditParametersModel model)
        {
            var major = this.majorRepository.All().FirstOrDefault(m => m.Id == id);

            if (major == null)
            {
                return false;
            }

            var departmentId = this.departmentRepository.All()
                .Where(d => d.Name == model.BelongsToDepartment)
                .Select(d => d.Id)
                .FirstOrDefault();

            major.Name = model.Name;
            major.Description = model.Description;
            major.MajorType = model.MajorType;
            major.Duration = model.Duration;
            major.DepartmentId = departmentId;

            await this.majorRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
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
