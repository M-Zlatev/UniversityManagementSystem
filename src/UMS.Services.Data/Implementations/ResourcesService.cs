namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Mapping.Infrastructure;
    using UMS.Data;
    using UMS.Data.Models.Courses;
    using UMS.Data.Models.Resources;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Resources;

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

        public async Task<int> CreateAsync(CreateResourceInputForm createForm)
        {
            int courseId = this.FindCourseIdByCourseName(createForm.BelongToCourse);

            var resource = new Resource
            {
                Name = createForm.Name,
                ResourceType = createForm.ResourceType,
                Url = createForm.Url,
                CourseId = courseId,
            };

            await this.resourceRepository.AddAsync(resource);
            await this.resourceRepository.SaveChangesAsync();

            return resource.Id;
        }

        public async Task<bool> EditAsync(int id, EditResourceInputForm editForm)
        {
            var resource = this.resourceRepository.All().FirstOrDefault(m => m.Id == id);

            if (resource == null)
            {
                return false;
            }

            int courseId = this.FindCourseIdByCourseName(editForm.BelongToCourse);

            resource.Name = editForm.Name;
            resource.ResourceType = editForm.ResourceType;
            resource.Url = editForm.Url;
            resource.CourseId = courseId;

            await this.resourceRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
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
