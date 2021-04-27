namespace UMS.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Contracts;
    using Data.Models.HomeworksParametersModels;
    using Mapping.Infrastructure;
    using UMS.Data.Models.Homeworks;
    using UMS.Data.Repositories.Contracts;

    public class HomeworksService //: IHomeworksService
    {
        private const int HomeworksPageSize = 10;

        private readonly IRepository<Homework> homeworkRepository;
        //private readonly IDeletableEntityRepository<Student> studentRepository;

        public HomeworksService(
            IRepository<Homework> homeworkRepository)
            //IDeletableEntityRepository<Student> studentRepository)
        {
            this.homeworkRepository = homeworkRepository;
            //this.studentRepository = studentRepository;
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

        //public async Task<int> CreateAsync(HomeworkCreateParametersModel model)
        //{
        //    var homework = new Homework
        //    {
        //        Content = model.Content,
        //        HomeworkType = model.HomeworkType,
        //        AssignmentTime = model.AssingmentTime,
        //        OpenForSubmissionTime = model.OpenForSubmissionTime,
        //        AddedByUserId = model.UserId,
        //    };

        //    var studentName = this.homeworkRepository.AllAsNoTracking()
        //        .Where(h => h.AddedByUserId == model.UserId)
        //        .Select(s => s.Student.FirstName)
        //        .FirstOrDefault();

        //    var student = this.studentRepository.All()
        //        .Where(s => s.FirstName == studentName)
        //        .FirstOrDefault();

        //    student.Homeworks.Add(homework);

        //    await this.homeworkRepository.AddAsync(homework);

        //    await this.homeworkRepository.SaveChangesAsync();
        //    await this.studentRepository.SaveChangesAsync();

        //    return homework.Id;
        //}

        public async Task<bool> EditAsync(int id, HomeworkEditParametersModel model)
        {
            var homework = this.homeworkRepository.All().FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return false;
            }

            homework.Content = model.Content;
            homework.HomeworkType = model.HomeworkType;
            homework.OpenForSubmissionTime = model.OpenForSubmissionTime;

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
