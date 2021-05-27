namespace UMS.Web.Areas.Identity.Pages.Account
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Text.Encodings.Web;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.AspNetCore.WebUtilities;
    using Microsoft.Extensions.Logging;

    using Data.Models.UserDefinedPrincipal;
    using Data.Common.Enumerations;
    using static Data.Common.DataValidation.ApplicationUser;

    [AllowAnonymous]
    public class Register : PageModel
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<Register> logger;
        private readonly IEmailSender emailSender;

        public Register(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<Register> logger,
            IEmailSender emailSender)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
            this.emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= this.Url.Content("~/");
            this.ExternalLogins = (await this.signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = this.Input.Username,
                    Email = this.Input.Email,
                    FirstName = this.Input.FirstName,
                    MiddleName = this.Input.MiddleName,
                    LastName = this.Input.LastName,
                    Gender = this.Input.Gender,
                    DateOfBirth = this.Input.DateOfBirth,
                    PhoneNumber = this.Input.PhoneNumber,
                };

                var userAddress = new ApplicationUserAddress()
                {
                    StreetName = this.Input.Address.StreetName,
                    District = this.Input.Address.District,
                    Town = this.Input.Address.Town,
                    PostalCode = this.Input.Address.PostalCode,
                    Country = this.Input.Address.Country,
                    Continent = this.Input.Address.Continent,
                    User = user,
                    UserId = user.Id,
                };

                user.Address = userAddress;

                var result = await this.userManager.CreateAsync(user, this.Input.Password);

                if (result.Succeeded)
                {
                    // Add role to user
                    var role = await this.userManager.AddToRoleAsync(user, this.Input.AppRole.ToString());

                    this.logger.LogInformation("User created a new account with password.");

                    var code = await this.userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = this.Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: this.Request.Scheme);

                    await this.emailSender.SendEmailAsync(
                        this.Input.Email,
                        "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (this.userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return this.RedirectToPage("RegisterConfirmation", new { email = this.Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        // prevent showing twice in a row - "You log in for the first time" message in "last time you visit the page"
                        // shows the correct time after the second time we log in (the first time is done automatically after the registration)
                        user.CurrentLoginTime = DateTime.Now;
                        await this.userManager.UpdateAsync(user);

                        await this.signInManager.SignInAsync(user, isPersistent: false);
                        return this.LocalRedirect(returnUrl);
                    }
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            public string Username { get; set; }

            [Display(Name = "")]
            public AppRole AppRole { get; set; }

            [Display(Name="First name")]
            public string FirstName { get; set; }

            [Display(Name = "Middle name")]
            public string MiddleName { get; set; }

            [Display(Name = "Last name")]
            public string LastName { get; set; }

            public Gender Gender { get; set; }

            [Display(Name = "Date of birth")]
            public DateTime DateOfBirth { get; set; }

            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            public ApplicationUserAddress Address { get; set; }

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
