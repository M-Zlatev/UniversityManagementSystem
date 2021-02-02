namespace UMS.Web
{
    using System.Reflection;

    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Common.Mapping;
    using Controllers;
    using Data;
    using Data.Models;
    using Infrastructure;
    using Models;
    using Services.Contracts;
    using Services.Implementations;
    using ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
            => this.configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<UmsDbContext>(options => options
                    .UseSqlServer(this.configuration.GetDefaultConnectionString()));

            services
                .AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<UmsDbContext>();

            // Automatically register Transient / Singleton / Scoped services
            services.AddConventionalServices();

            services.AddAdditionalMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorsViewModel).GetTypeInfo().Assembly);

            app.UseDataSeeding(env);

            app.UseExceptionHandling(env);

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints();
        }
    }
}
