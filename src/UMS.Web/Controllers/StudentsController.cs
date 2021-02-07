namespace UMS.Web.Controllers
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using System.Linq;

    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models;
    using Infrastructure;
    using Services.Contracts;
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
        public async Task<IActionResult> Create(StudentFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var studentId = await this.studentService.Create(model.FirstName, model.MiddleName, model.LastName, model.UniformCivilNumber, model.DateOfBirth, model.Gender, model.AddressStreetName, model.AddressTownName, model.AddressDistrictName, model.AddressCountryName, model.AddressContinentName, model.MajorName, model.PhoneNumber, model.Email, model.ImageUrl, model.HasScholarship, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = studentId });
            }

            return this.View(model);
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
        public async Task<IActionResult> Edit(int id, StudentFormModel model)
        {
            if (!await this.studentService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.studentService.Edit(id, model.FirstName, model.MiddleName, model.LastName, model.UniformCivilNumber, model.DateOfBirth, model.Gender, model.AddressStreetName, model.AddressTownName, model.AddressDistrictName, model.AddressCountryName, model.AddressContinentName, model.MajorName, model.PhoneNumber, model.Email, model.ImageUrl, model.HasScholarship);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
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
