namespace UMS.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using Common.Mapping;
    using UMS.Data;
    using UMS.Data.Common.Enumerations;
    using UMS.Data.Models;
    using UMS.Services.Contracts;

    public class HomeworksService : IHomeworksService
    {
        private const int HomeworksPageSize = 10;

        private readonly UmsDbContext data;

        public HomeworksService(UmsDbContext dbContext)
            => this.data = dbContext;

        public IEnumerable<T> GetAll<T>(int page, int homeworksPerPage = HomeworksPageSize)
            => this.data
            .Homeworks
            .OrderBy(h => h.Id)
            .Skip((page - 1) * homeworksPerPage)
            .Take(homeworksPerPage)
            .To<T>()
            .ToList();

        public T GetDetailsById<T>(int id)
            => this.data
            .Homeworks
            .Where(h => h.Id == id)
            .To<T>()
            .FirstOrDefault();

        public async Task<bool> Exists(int id)
            => await this.data.Homeworks.AnyAsync(h => h.Id == id);

        public int GetCount()
            => this.data.Homeworks.Count();

        public async Task<int> Create(string content, HomeworkType homeworkType, DateTime assignmentTime, DateTime openForSubmissionTime, string doneByStudent)
        {
            var studentId = this.data
                .Students
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

            var student = this.data
                .Students
                .Where(s => s.FirstName == doneByStudent)
                .FirstOrDefault();

            student.Homeworks.Add(homework);

            this.data.Homeworks.Add(homework);

            await this.data.SaveChangesAsync();

            return homework.Id;
        }

        public async Task<bool> Edit(int id, string content, HomeworkType homeworkType, DateTime assignmentTime, DateTime openForSubmissionTime)
        {
            var homework = await this.data.Homeworks.FindAsync(id);

            if (homework == null)
            {
                return false;
            }

            CheckDate(assignmentTime, openForSubmissionTime);

            homework.Content = content;
            homework.HomeworkType = homeworkType;
            homework.AssignmentTime = assignmentTime;
            homework.OpenForSubmissionTime = openForSubmissionTime;

            await this.data.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var homework = this.data.Homeworks.FindAsync(id);

            if (homework == null)
            {
                return false;
            }

            this.data.Remove(homework);

            await this.data.SaveChangesAsync();

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
