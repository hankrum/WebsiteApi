using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data;
using Api.Data.Services;
using Api.Data.Repository;
using Api.Data.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;


namespace Api.Host
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            this.RegisterData(services);
            this.RegistrServices(services);
        }

        private void RegisterData(IServiceCollection services)
        {
            services.AddDbContext<MsSqlDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("WebSiteContext")));

            services.BuildServiceProvider().GetService<MsSqlDbContext>().Database.Migrate();

            services.AddScoped(typeof(IEfRepository<>), typeof(EFRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private void RegistrServices(IServiceCollection services)
        {
            services.AddTransient<IWebsiteService, WebsiteService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
