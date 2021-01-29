namespace UMS.Web.Infrastructure
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMVC(this IServiceCollection services)
        {
            services.AddControllersWithViews(options => options
                .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddRazorPages();

            return services;
        }
    }
}
