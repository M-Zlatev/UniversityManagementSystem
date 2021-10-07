namespace UMS.Services.Data.Contracts.Administration
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;

    using Services.Contracts.ServicesLifetimeContracts;
    using UMS.Data.Models.UserDefinedPrincipal;
    using UMS.Web.ViewModels.Administration;

    public interface IAdministrationService : ITransientService
    {
        Task<IdentityResult> EditAsync(ApplicationUser user, EditUserViewModel editForm);

        public T GetDetailsForUser<T>(ApplicationUser user);
    }
}
