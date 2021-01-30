namespace UMS.Web.Infrastructure
{
    using System.Linq;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    using Common;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConventionalService(
            this IServiceCollection services)
        {
            var serviceInterfaceType = typeof(ITransientService);
            var singletonInterfaceType = typeof(ISingletonService);
            var scopedInterfaceType = typeof(IScopedService);

            var types = serviceInterfaceType
                .Assembly
                .GetExportedTypes()
                .Where(t => t.IsClass && !t.IsAbstract)
                .Select(t => new
                {
                    Service = t.GetInterface($"I{t.Name}"),
                    Implementation = t,
                })
                .Where(t => t.Service != null);

            foreach (var type in types)
            {
                if (serviceInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddTransient(type.Service, type.Implementation);
                }
                else if (singletonInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddSingleton(type.Service, type.Implementation);
                }
                else if (scopedInterfaceType.IsAssignableFrom(type.Service))
                {
                    services.AddScoped(type.Service, type.Implementation);
                }
            }

            return services;
        }

        public static IServiceCollection AddAdditionalMvc(this IServiceCollection services)
        {
            services.AddControllersWithViews(options => options
                .Filters.Add(new AutoValidateAntiforgeryTokenAttribute()));

            services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddRazorPages();

            return services;
        }
    }
}
