﻿namespace UMS.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Infrastructure;
    using Services.Contracts;
    using ViewModels;
    using ViewModels.Courses;

    public class CoursesController : Controller
    {
        private readonly ICoursesService coursesService;

        public CoursesController(ICoursesService coursesService)
            => this.coursesService = coursesService;

        public IActionResult Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int CoursesPerPage = 20;

            var viewModel = new CourseGetAllViewModel
            {
                ItemsPerPage = CoursesPerPage,
                PageNumber = id,
                Courses = this.coursesService.GetAll<CourseListingViewModel>(id, CoursesPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.coursesService.GetDetails<CourseDetailsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create(int id)
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CourseFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var courseId = await this.coursesService.Create(
                    model.Name, model.Description, model.StartDate, model.EndDate, model.Price, model.BelongsToMajor, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = courseId });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, CourseFormModel model)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.coursesService.Edit(id, model.Name, model.Description, model.StartDate, model.EndDate, model.Price, model.BelongsToMajor);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.coursesService.Exists(id))
            {
                return this.NotFound();
            }

            await this.coursesService.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
