namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Services.Contracts;

    public class ResourcesService : IResourcesService
    {
        private const int ResourcesPageSize = 10;

        private readonly UmsDbContext data;

        public ResourcesService(UmsDbContext dbContext)
            => this.data = dbContext;

        public IEnumerable<T> GetAll<T>(int page, int resourcesPerPage = ResourcesPageSize)
            => this.data
            .Resources
            .OrderBy(r => r.Id)
            .Skip((page - 1) * resourcesPerPage)
            .Take(resourcesPerPage)
            .To<T>()
            .ToList();

        public T GetDetailsById<T>(int id)
            => this.data
            .Resources
            .Where(r => r.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.data.Resources.AnyAsync(r => r.Id == id);

        public int GetCount()
            => this.data.Resources.Count();

        public async Task<int> Create(string name, ResourceType resourceType, string url, string belongToCourse)
        {
            int courseId = this.FindCourseIdByCourseName(belongToCourse);

            var resource = new Resource
            {
                Name = name,
                ResourceType = resourceType,
                Url = url,
                CourseId = courseId,
            };

            this.data.Resources.Add(resource);

            await this.data.SaveChangesAsync();

            return resource.Id;
        }

        public async Task<bool> Edit(int id, string name, ResourceType resourceType, string url, string belongToCourse)
        {
            var resource = await this.data.Resources.FindAsync(id);

            if (resource == null)
            {
                return false;
            }

            int courseId = this.FindCourseIdByCourseName(belongToCourse);

            resource.Name = name;
            resource.ResourceType = resourceType;
            resource.Url = url;
            resource.CourseId = courseId;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var resource = this.data.Resources.FindAsync(id);

            if (resource == null)
            {
                return false;
            }

            this.data.Remove(resource);

            await this.data.SaveChangesAsync();

            return true;
        }

        private int FindCourseIdByCourseName(string belongToCourse)
        {
            return this.data
                .Courses
                .Where(c => c.Name == belongToCourse)
                .Select(c => c.Id)
                .FirstOrDefault();
        }
    }
}
