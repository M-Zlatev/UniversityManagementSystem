namespace UMS.Services.Data.Implementations.Administration
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Contracts.Administration;
    using UMS.Data.Models.UserDefinedPrincipal;
    using UMS.Web.ViewModels.Administration;
    using UMS.Services.Mapping.Infrastructure;
    using UMS.Data.Repositories.Contracts;

    public class AdministrationService : IAdministrationService
    {
        private readonly RoleManager<ApplicationRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<ApplicationUserAddress> addressRepository;

        public AdministrationService(
            RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            IRepository<ApplicationUserAddress> addressRepository)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.addressRepository = addressRepository;
        }

        public T GetDetailsForUser<T>(ApplicationUser user)
            => this.userManager
                    .Users
                    .Where(u => u.UserName == user.UserName)
                    .To<T>()
                    .FirstOrDefault();

        public async Task<IdentityResult> EditAsync(ApplicationUser user, EditUserViewModel editForm)
        {
            var userAddress = this.addressRepository.All()
                .Where(u => u.UserId == user.Id)
                .FirstOrDefault();

            user.Id = editForm.Id;
            user.Email = editForm.Email;
            user.UserName = editForm.UserName;

            userAddress.StreetName = editForm.Street;
            userAddress.Town = editForm.Town;
            userAddress.District = editForm.District;
            userAddress.PostalCode = editForm.PostalCode;
            userAddress.Country = editForm.Country;
            userAddress.Continent = editForm.Continent;

            var result = await this.userManager.UpdateAsync(user);

            return result;
        }
    }
}
