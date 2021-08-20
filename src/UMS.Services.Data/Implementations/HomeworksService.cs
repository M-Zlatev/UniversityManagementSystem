namespace UMS.Services.Data.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Mapping.Infrastructure;
    using UMS.Data.Models.Homeworks;
    using UMS.Data.Models.UserDefinedPrincipal;
    using UMS.Data.Repositories.Contracts;
    using UMS.Web.ViewModels.Homeworks;

    public class HomeworksService : IHomeworksService
    {
        private const int HomeworksPageSize = 10;

        private readonly IRepository<Homework> homeworkRepository;
        private readonly UserManager<ApplicationUser> userManager;

        public HomeworksService(
            IRepository<Homework> homeworkRepository,
            UserManager<ApplicationUser> userManager)
        {
            this.homeworkRepository = homeworkRepository;
            this.userManager = userManager;
        }

        public IEnumerable<T> GetAll<T>(int page, int homeworksPerPage = HomeworksPageSize)
            => this.homeworkRepository.AllAsNoTracking()
            .OrderBy(h => h.Id)
            .Skip((page - 1) * homeworksPerPage)
            .Take(homeworksPerPage)
            .To<T>()
            .ToList();

        public T GetDetailsById<T>(int id)
            => this.homeworkRepository.AllAsNoTracking()
            .Where(h => h.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.homeworkRepository.All().AnyAsync(h => h.Id == id);

        public int GetCount()
            => this.homeworkRepository.All().Count();

        public async Task<int> CreateAsync(CreateHomeworkInputForm createForm)
        {
            var homework = new Homework
            {
                Content = createForm.Content,
                HomeworkType = createForm.HomeworkType,
                AssignmentTime = createForm.AssignmentTime,
                OpenForSubmissionTime = createForm.OpenForSubmissionTime,
                AddedByUserId = createForm.UserId,
            };

            var listOfAllUsers = this.userManager
                .Users
                .ToList();

            var currentUser = listOfAllUsers
                .Where(u => u.Id == createForm.UserId)
                .FirstOrDefault();

            currentUser.Homeworks.Add(homework);
            await this.homeworkRepository.AddAsync(homework);

            await this.homeworkRepository.SaveChangesAsync();

            return homework.Id;
        }

        public async Task<bool> EditAsync(int id, EditHomeworkInputForm editForm)
        {
            var homework = this.homeworkRepository.All().FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return false;
            }

            homework.Content = editForm.Content;
            homework.HomeworkType = editForm.HomeworkType;
            homework.OpenForSubmissionTime = editForm.OpenForSubmissionTime;

            await this.homeworkRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var homework = this.homeworkRepository.All().FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return false;
            }

            this.homeworkRepository.Delete(homework);

            await this.homeworkRepository.SaveChangesAsync();

            return true;
        }
    }
}
