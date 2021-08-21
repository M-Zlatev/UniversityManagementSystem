namespace UMS.Web.Infrastructure.Extensions
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.DependencyInjection;

    using Data.Contracts;
    using Data.Infrastructure;
    using Data.Repositories.Contracts;
    using Data.Repositories.Implementations;
    using Services.Contracts;
    using Services.Contracts.ServicesLifetimeContracts;
    using Services.Data.Contracts;
    using Services.Mapping;
    using ViewModels.Contracts;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConventionalServices(
            this IServiceCollection services)
        {
            // Add all services from UMS.Services
            AddServices(services, typeof(IService));

            // Add all services from UMS.Services.Data
            AddServices(services, typeof(IServiceData));

            // Additional services
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

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

        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            CustomAutoMapper.Initialize(typeof(IViewModel).GetTypeInfo().Assembly);

            return services;
        }

        public static IServiceCollection AddCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            return services;
        }

        private static void AddServices(IServiceCollection services, Type interfaceType)
        {
            var transientInterfaceType = typeof(ITransientService);
            var singletonInterfaceType = typeof(ISingletonService);
            var scopedInterfaceType = typeof(IScopedService);

            var types = interfaceType
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
                if (transientInterfaceType.IsAssignableFrom(type.Service))
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
        }
    }
}
