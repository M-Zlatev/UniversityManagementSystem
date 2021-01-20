namespace UMS.Web
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Data;
    using Data.Models;
    using Infrastructure;

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
                .AddDefaultIdentity<IdentityUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddEntityFrameworkStores<UmsDbContext>();

            services.AddControllersWithViews();
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApplyMigration(env);

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
