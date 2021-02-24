namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using Contracts;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Data.Repositories;

    public class HomeworksService : IHomeworksService
    {
        private const int HomeworksPageSize = 10;

        private readonly IRepository<Homework> homeworkRepository;
        private readonly IDeletableEntityRepository<Student> studentRepository;

        public HomeworksService(
            IRepository<Homework> homeworkRepository,
            IDeletableEntityRepository<Student> studentRepository)
        {
            this.homeworkRepository = homeworkRepository;
            this.studentRepository = studentRepository;
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

        public async Task<int> Create(string content, HomeworkType homeworkType, DateTime assignmentTime, DateTime openForSubmissionTime, string doneByStudent)
        {
            var studentId = this.studentRepository.AllAsNoTracking()
                .Where(s => s.FirstName == doneByStudent)
                .Select(s => s.Id)
                .FirstOrDefault();

            CheckDate(assignmentTime, openForSubmissionTime);

            var homework = new Homework
            {
                Content = content,
                HomeworkType = homeworkType,
                AssignmentTime = assignmentTime,
                OpenForSubmissionTime = openForSubmissionTime,
                StudentId = studentId,
            };

            var student = this.studentRepository.AllAsNoTracking()
                .Where(s => s.FirstName == doneByStudent)
                .FirstOrDefault();

            student.Homeworks.Add(homework);

            await this.homeworkRepository.AddAsync(homework);

            await this.homeworkRepository.SaveChangesAsync();
            await this.studentRepository.SaveChangesAsync();

            return homework.Id;
        }

        public async Task<bool> Edit(int id, string content, HomeworkType homeworkType, DateTime assignmentTime, DateTime openForSubmissionTime)
        {
            var homework = this.homeworkRepository.All().FirstOrDefault(h => h.Id == id);

            if (homework == null)
            {
                return false;
            }

            CheckDate(assignmentTime, openForSubmissionTime);

            homework.Content = content;
            homework.HomeworkType = homeworkType;
            homework.AssignmentTime = assignmentTime;
            homework.OpenForSubmissionTime = openForSubmissionTime;

            await this.homeworkRepository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
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

        private static void CheckDate(DateTime assignmentTime, DateTime openForSubmissionTime)
        {
            if (assignmentTime == null)
            {
                assignmentTime = DateTime.UtcNow;
            }

            if (openForSubmissionTime == null)
            {
                openForSubmissionTime = DateTime.UtcNow.AddDays(7);
            }
        }
    }
}
