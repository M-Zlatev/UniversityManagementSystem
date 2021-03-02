namespace UMS.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using AutoMapper;
    using AutoMapper.Configuration;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Data.Models;
    using Data.Repositories;
    using Infrastructure;
    using Services.Contracts;
    using Services.Data.Models.CoursesParametersModels;
    using ViewModels;
    using ViewModels.Courses;

    public class CoursesController : Controller
    {
        private readonly IDeletableEntityRepository<Course> courseRepository;
        private readonly ICoursesService coursesService;

        public CoursesController(ICoursesService coursesService, IDeletableEntityRepository<Course> courseRepository)
        {
            this.coursesService = coursesService;
            this.courseRepository = courseRepository;
        }

        public IActionResult All(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int CoursesPerPage = 20;

            var viewModel = new CourseGetAllViewModel
            {
                ItemsPerPage = CoursesPerPage,
                Count = this.coursesService.GetCount(),
                PageNumber = id,
                Courses = this.coursesService.GetAll<CourseListingViewModel>(id, CoursesPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult ById(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.coursesService.GetDetailsById<CourseGetDetailsByIdViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new CreateCourseInputForm();
            viewModel.MajorItems = this.coursesService.GetAllAsKeyValuePairs();

            return this.View(viewModel);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Create(CreateCourseInputForm courseInputForm)
        {
            if (this.ModelState.IsValid)
            {
                courseInputForm.MajorItems = this.coursesService.GetAllAsKeyValuePairs();

                var parameters = AutoMapperConfig.MapperInstance.Map<CourseCreateParametersModel>(courseInputForm);

                var courseId = await this.coursesService.CreateAsync(parameters);

                return this.RedirectToAction(nameof(this.ById), new { id = courseId });
            }

            return this.View(courseInputForm);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            var inputModel = this.coursesService.GetDetailsById<EditCourseInputForm>(id);
            return this.View(inputModel);
        }

        [HttpPost]
        //[Authorize]
        public async Task<IActionResult> Edit(int id, EditCourseInputForm courseInputForm)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<CourseEditParametersModel>(courseInputForm);
                await this.coursesService.EditAsync(id, parameters);

                return this.RedirectToAction(nameof(this.ById), new { id });
            }

            return this.View(courseInputForm);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            var course = this.courseRepository.All()
                .Where(c => c.Id == id)
                .FirstOrDefault();

            return this.View(course);
        }

        [HttpPost]
        //[Authorize]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            await this.coursesService.DeleteAsync(id);

            return this.RedirectToAction(nameof(this.All));
        }
    }
}
