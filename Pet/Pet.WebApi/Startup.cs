using Microsoft.EntityFrameworkCore;

using Pets.Domain.Interfaces;
using Pets.Domain.Services;
using Pets.Repository;
using System.Reflection;

using Pets.Domain.Mapper;
using Microsoft.AspNetCore.Mvc.Formatters;

using Newtonsoft.Json;

using Pets.WebApi.Helpers;

namespace Pets.WebApi
{
    /// <summary>
    /// Startup
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Configuration
        /// </summary>
        public IConfiguration Configuration;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configure Services
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(static options =>
            {
                options.OutputFormatters.RemoveType<StringOutputFormatter>();
            }).AddNewtonsoftJson(static jsonOptions =>
            {
                jsonOptions.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                jsonOptions.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Populate;
                jsonOptions.SerializerSettings.Converters.Add(new NullToDefaultJsonConverter());
            });

            services.AddAutoMapper(typeof(MapperProfile));

            AddDependencyInjections(services);

            var mySqlConnection = Configuration.GetConnectionString("DefaultConnection");
            if (string.IsNullOrWhiteSpace(mySqlConnection))
            {
                throw new Exception("Invalid connection string");
            }

            services.AddDbContextPool<ApplicationDbContext>(options => options.UseMySql(mySqlConnection, ServerVersion.AutoDetect(mySqlConnection)));

            services.AddSwaggerGen(static options =>
            {
                // For Enable Summary comments in Swagger (and <GenerateDocumentationFile>true</GenerateDocumentationFile>)
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        /// <summary>
        /// Configure App
        /// </summary>
        /// <param name="app"></param>
        /// <param name="enviroment"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment enviroment)
        {
            if (enviroment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(static builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            // Difference between UseRouting/UseEndpoints https://thecodeblogger.com/2021/05/27/asp-net-core-web-application-routing-and-endpoint-internals/
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(static endpoints => endpoints.MapControllers());
        }

        /// <summary>
        /// Add Dependency Injections
        /// </summary>
        /// <param name="services"></param>
        private static void AddDependencyInjections(IServiceCollection services)
        {
            services.AddTransient<IPetService, PetService>();
        }
    }
}
