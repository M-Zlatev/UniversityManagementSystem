namespace UMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Common.Mapping;
    using Data.Models;
    using Infrastructure;
    using Services.Contracts;
    using Services.Data.Models.StudentsParametersModels;
    using ViewModels;
    using ViewModels.Students;

    public class StudentsController : Controller
    {
        private readonly IStudentsService studentService;

        public StudentsController(IStudentsService studentService)
        {
            this.studentService = studentService;
        }

        public IActionResult Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int StudentsPerPage = 10;

            var viewModel = new StudentGetAllViewModel
            {
                ItemsPerPage = StudentsPerPage,
                Count = this.studentService.GetCount(),
                PageNumber = id,
                Students = this.studentService.GetAll<StudentListingViewModel>(id, StudentsPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.studentService.GetDetails<StudentDetailsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateStudentInputForm studentInputForm)
        {
            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<StudentCreateParametersModel>(studentInputForm);
                var studentId = await this.studentService.Create(parameters);

                return this.RedirectToAction(nameof(this.Details), new { id = studentId });
            }

            return this.View(studentInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, EditStudentInputForm studentInputForm)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                var parameters = AutoMapperConfig.MapperInstance.Map<StudentEditParametersModel>(studentInputForm);
                await this.studentService.Edit(id, parameters);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(studentInputForm);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            await this.studentService.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
