namespace UMS.Web.Areas.Identity.Pages.Account.Manage
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;

    using Data.Common.Enumerations;
    using Data.Models.UserDefinedPrincipal;

    public partial class IndexModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public IndexModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public string Username { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            await this.LoadAsync(user);
            return this.Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await this.userManager.GetUserAsync(this.User);
            if (user == null)
            {
                return this.NotFound($"Unable to load user with ID '{this.userManager.GetUserId(this.User)}'.");
            }

            if (!this.ModelState.IsValid)
            {
                await this.LoadAsync(user);
                return this.Page();
            }

            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);
            if (this.Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await this.userManager.SetPhoneNumberAsync(user, this.Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    this.StatusMessage = "Unexpected error when trying to set phone number.";
                    return this.RedirectToPage();
                }
            }

            await this.signInManager.RefreshSignInAsync(user);
            this.StatusMessage = "Your profile has been updated";
            return this.RedirectToPage();
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var userName = await this.userManager.GetUserNameAsync(user);
            var phoneNumber = await this.userManager.GetPhoneNumberAsync(user);

            this.Username = userName;

            // If we user directly user.Address in the InputModel down below we have got 'Null Reference Exception', because user.Address is still 'Null', probably due to async operations in this method
            var userAddress = this.userManager.Users
                .Where(u => u.Id == user.Id)
                .Select(ua => ua.Address)
                .FirstOrDefault();

            this.Input = new InputModel
            {
                FirstName = user.FirstName,
                MiddleName = user.MiddleName,
                LastName = user.LastName,
                Birthdate = user.DateOfBirth,
                PhoneNumber = phoneNumber,
                Gender = user.Gender,
                ImageUrl = user.ImageUrl,
                FacultyNumber = user.FacultyNumber,
                HasScholarship = user.HasScholarship,
                AcademicDegree = user.AcademicDegree,
                AcademicRank = user.AcademicRank,
                Address = userAddress,
            };
        }

        public class InputModel
        {
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [Display(Name = "Last name")]
            public string LastName { get; set; }

            [Display(Name = "Date of birth")]
            public DateTime? Birthdate { get; set; }

            public Gender Gender { get; set; }

            public ApplicationUserAddress Address { get; set; }

            public string StreetName { get; set; }

            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Display(Name = "Profile picture")]
            public string ImageUrl { get; set; }

            [Display(Name = "Faculty number")]
            public string FacultyNumber { get; set; }

            [Display(Name = "Scholarship")]
            public bool HasScholarship { get; set; }

            [Display(Name = "Academic degree")]
            public AcademicDegree AcademicDegree { get; set; }

            [Display(Name = "Academic rank")]
            public AcademicRank AcademicRank { get; set; }
        }
    }
}
