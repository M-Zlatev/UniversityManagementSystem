namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using Data.Models.ResourcesParametersModels;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Data.Repositories;

    public class ResourcesService : IResourcesService
    {
        private const int ResourcesPageSize = 10;

        private readonly IRepository<Resource> resourceRepository;
        private readonly IDeletableEntityRepository<Course> courseRepository;

        public ResourcesService(
            UmsDbContext dbContext,
            IRepository<Resource> resourceRepository,
            IDeletableEntityRepository<Course> courseRepository)
        {
            this.resourceRepository = resourceRepository;
            this.courseRepository = courseRepository;
        }

        public IEnumerable<T> GetAll<T>(int page, int resourcesPerPage = ResourcesPageSize)
            => this.resourceRepository.AllAsNoTracking()
            .OrderBy(r => r.Id)
            .Skip((page - 1) * resourcesPerPage)
            .Take(resourcesPerPage)
            .To<T>()
            .ToList();

        public T GetDetailsById<T>(int id)
            => this.resourceRepository.AllAsNoTracking()
            .Where(r => r.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.resourceRepository.All().AnyAsync(r => r.Id == id);

        public int GetCount()
            => this.resourceRepository.All().Count();

        public async Task<int> Create(ResourceCreateParametersModel model)
        {
            int courseId = this.FindCourseIdByCourseName(model.BelongToCourse);

            var resource = new Resource
            {
                Name = model.Name,
                ResourceType = model.ResourceType,
                Url = model.Url,
                CourseId = courseId,
            };

            await this.resourceRepository.AddAsync(resource);

            await this.resourceRepository.SaveChangesAsync();

            return resource.Id;
        }

        public async Task<bool> Edit(int id, ResourceEditParametersModel model)
        {
            var resource = this.resourceRepository.All().FirstOrDefault(m => m.Id == id);

            if (resource == null)
            {
                return false;
            }

            int courseId = this.FindCourseIdByCourseName(model.BelongToCourse);

            resource.Name = model.Name;
            resource.ResourceType = model.ResourceType;
            resource.Url = model.Url;
            resource.CourseId = courseId;

            await this.resourceRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var resource = this.resourceRepository.All().FirstOrDefault(m => m.Id == id);

            if (resource == null)
            {
                return false;
            }

            this.resourceRepository.Delete(resource);

            await this.resourceRepository.SaveChangesAsync();

            return true;
        }

        private int FindCourseIdByCourseName(string belongToCourse)
        {
            return this.courseRepository.All()
                .Where(c => c.Name == belongToCourse)
                .Select(c => c.Id)
                .FirstOrDefault();
        }
    }
}
