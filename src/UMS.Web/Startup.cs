namespace UMS.Web
{
    using AutoMapper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Controllers;
    using Data;
    using Data.Models;
    using Infrastructure;
    using Services.Contracts;
    using Services.Implementations;

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

            // Register AutoMapper
            services.AddAutoMapper(
                typeof(IFacultyService).Assembly,
                typeof(IDepartmentService).Assembly,
                typeof(IMajorService).Assembly,
                typeof(HomeController).Assembly);

            services.AddTransient<IFacultyService, FacultyService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
            services.AddTransient<IMajorService, MajorService>();

            services.AddMVC();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
