namespace UMS.Web.Areas.Administration.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Data.Models.UserDefinedPrincipal;
    using ViewModels.Administration;
    using Services.Data.Contracts.Administration;
    using static Infrastructure.Extensions.CustomAutoMapperExtension;

    [Area("Administration")]
    public class AdministratorController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAdministrationService administrationService;

        public AdministratorController(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IAdministrationService administrationService)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.administrationService = administrationService;
        }

        public IActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public IActionResult ListUsers()
        {
            var users = this.userManager.Users;

            return this.View(users);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return this.RedirectToAction("Register", "Account", new { area = "Identity" });
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(int id)
        {
            var user = await this.userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                this.ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return this.View("NotFound");
            }

            var viewModel = this.administrationService.GetDetailsForUser<EditUserViewModel>(user);

            var userRoles = await this.userManager.GetRolesAsync(user);
            viewModel.Roles = userRoles;

            if (user.LastVisitedLoginTime == null && user.CurrentLoginTime != null)
            {
                viewModel.LastVisitedLoginTime = user.CurrentLoginTime;
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await this.userManager.FindByIdAsync(model.Id.ToString());

            if (user == null)
            {
                this.ViewBag.ErrorMessage = $"User with Id = {model.Id} cannot be found";
                return this.View("NotFound");
            }
            else
            {
                var result = this.administrationService.EditAsync(user, model).Result;

                if (result.Succeeded)
                {
                    return this.RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError("", error.Description);
                }

                return this.View(model);
            }
        }

        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await this.userManager.FindByIdAsync(id.ToString());

            if (user == null)
            {
                this.ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return this.View("NotFound");
            }
            else
            {
                var result = await this.userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("ListUsers");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError("", error.Description);
                }

                return this.View("ListUsers");
            }
        }

        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = this.roleManager.Roles;
            return this.View(roles);
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                ApplicationRole appRole = new ApplicationRole
                {
                    Name = model.RoleName,
                };

                IdentityResult result = await this.roleManager.CreateAsync(appRole);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("ListRoles", "Home");
                }

                foreach (IdentityError error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(int id)
        {
            var role = await this.roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return this.View("NotFound");
            }

            var model = new EditRoleViewModel()
            {
                Id = role.Id,
                RoleName = role.Name,
            };

            foreach (var user in this.userManager.Users)
            {
                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    model.Users.Add(user.UserName);
                }
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EdiRole(EditRoleViewModel model)
        {
            var role = await this.roleManager.FindByIdAsync(model.Id.ToString());

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {model.Id} cannot be found";
                return this.View("NotFound");
            }
            else
            {
                role.Name = model.RoleName;

                var result = await this.roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError("", error.Description);
                }

                return this.View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(int roleId)
        {
            this.ViewBag.roleId = roleId;

            var role = await this.roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                this.ViewBag.ErroMessage = $"Role with Id = {roleId} cannot be found!";
                return this.View("NotFound");
            }

            var model = new List<UserRoleViewModel>();

            foreach (var user in this.userManager.Users)
            {
                var userRoleViewModel = new UserRoleViewModel
                {
                    UserId = user.Id,
                    UserName = user.UserName,
                };

                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    userRoleViewModel.IsSelected = true;
                }
                else
                {
                    userRoleViewModel.IsSelected = false;
                }

                model.Add(userRoleViewModel);
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, int roleId)
        {
            var role = await this.roleManager.FindByIdAsync(roleId.ToString());

            if (role == null)
            {
                this.ViewBag.ErroMessage = $"Role with Id = {roleId} cannot be found!";
                return this.View("NotFound");
            }

            for (int i = 0; i < model.Count; i++)
            {
                var user = await this.userManager.FindByIdAsync(model[i].UserId.ToString());

                IdentityResult result = null;

                if (model[i].IsSelected && !(await this.userManager.IsInRoleAsync(user, role.Name)))
                {
                    result = await this.userManager.AddToRoleAsync(user, role.Name);
                }
                else if (!model[i].IsSelected && await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    result = await this.userManager.RemoveFromRoleAsync(user, role.Name);
                }
                else
                {
                    continue;
                }

                if (result.Succeeded)
                {
                    if (i < (model.Count - 1))
                    {
                        continue;
                    }
                    else
                    {
                        return this.RedirectToAction("EditRole", new { Id = roleId });
                    }
                }
            }

            return this.RedirectToAction("EditRole", new { Id = roleId });
        }

        [HttpGet]
        public async Task<IActionResult> ManageUserRoles(int userId)
        {
            this.ViewBag.userId = userId;

            var user = await this.userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                this.ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return this.View("NotFound");
            }

            var model = new List<UserRolesViewModel>();

            foreach (var role in this.roleManager.Roles)
            {
                var userRolesViewModel = new UserRolesViewModel()
                {
                    RoleId = role.Id,
                    RoleName = role.Name,
                };

                if (await this.userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.IsSelected = true;
                }
                else
                {
                    userRolesViewModel.IsSelected = false;
                }

                model.Add(userRolesViewModel);
            }

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ManageUserRoles(List<UserRolesViewModel> model, int userId)
        {
            var user = await this.userManager.FindByIdAsync(userId.ToString());

            if (user == null)
            {
                this.ViewBag.ErrorMessage = $"User with Id = {userId} cannot be found";
                return this.View("NotFound");
            }

            var roles = await this.userManager.GetRolesAsync(user);
            var result = await this.userManager.RemoveFromRolesAsync(user, roles);

            if (!result.Succeeded)
            {
                this.ModelState.AddModelError("", "Cannot remove user existing roles");
                return this.View(model);
            }

            result = await this.userManager.AddToRolesAsync(
                user, model.Where(x => x.IsSelected).Select(y => y.RoleName));

            if (!result.Succeeded)
            {
                this.ModelState.AddModelError("", "Cannot add selected roles to user");
                return this.View(model);
            }

            return this.RedirectToAction("EditUser", new { Id = userId });
        }

        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await this.roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                this.ViewBag.ErrorMessage = $"Role with Id = {id} cannot be found";
                return this.View("NotFound");
            }
            else
            {
                var result = await this.roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    return this.RedirectToAction("ListRoles");
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError("", error.Description);
                }

                return this.View("ListRoles");
            }
        }
    }
}
