using CompanyEmployees.ActionFilters;
using CompanyEmployees.Extensions;
using Contracts;
using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using Repository.DataShaping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.ConfigureVersioning();
            services.ConfigureCors();
            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            services.ConfigureIISIntegration();
            services.ConfigureLoggerService();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureRepositoryManager();
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<IDataShaper<EmployeeDto>, DataShaper<EmployeeDto>>();
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers(
                config =>
                {
                    config.RespectBrowserAcceptHeader = true;
                    config.ReturnHttpNotAcceptable = true;
                }).AddNewtonsoftJson()
                .AddXmlDataContractSerializerFormatters()
                .AddCustomCSVFormatter();

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigurExceptionHandler(logger);
            app.UseHttpsRedirection();
          
            app.UseStaticFiles();
            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions()
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

          //  app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                //Convention routing but not adviced by Asp.net core team
                /*endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                    );*/
            });
        }
    }
}
