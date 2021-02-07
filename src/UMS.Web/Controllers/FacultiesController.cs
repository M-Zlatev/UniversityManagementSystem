﻿namespace UMS.Web.Controllers
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
    using ViewModels.Faculties;

    public class FacultiesController : Controller
    {
        private readonly IFacultiesService facultyService;

        public FacultiesController(IFacultiesService faculties)
        {
            this.facultyService = faculties;
        }

        public IActionResult Index(int id = 1)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            const int FacultyPerPage = 10;

            var viewModel = new FacultyGetAllViewModel
            {
                ItemsPerPage = FacultyPerPage,
                PageNumber = id,
                Faculties = this.facultyService.GetAll<FacultyListingViewModel>(id, FacultyPerPage),
            };

            return this.View(viewModel);
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return this.NotFound();
            }

            var viewModel = this.facultyService.GetDetails<FacultyDetailsViewModel>(id);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
            => this.View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(FacultyFormModel model)
        {
            if (this.ModelState.IsValid)
            {
                var facultyId = await this.facultyService.Create(
                    model.Name, model.Description, model.AddressStreetName, model.AddressTownName, model.AddressCountryName, model.Email, model.PhoneNumber, model.Fax, this.User.GetUserId());

                return this.RedirectToAction(nameof(this.Details), new { id = facultyId });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(int id, FacultyFormModel model)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            if (this.ModelState.IsValid)
            {
                await this.facultyService.Edit(id, model.Name, model.Description, model.AddressStreetName, model.AddressTownName, model.AddressCountryName, model.Email, model.PhoneNumber, model.Fax);

                return this.RedirectToAction(nameof(this.Details), new { id });
            }

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            if (!await this.facultyService.Exists(id))
            {
                return this.NotFound();
            }

            await this.facultyService.Delete(id);

            return this.Redirect(nameof(this.Index));
        }
    }
}
