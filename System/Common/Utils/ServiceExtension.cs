using Entities.Models.DbAplikasi;
using Entities.Models.DbPenampung;
using Components;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Repositories;
using Services;
using System.Text;

// semua extension di sini digunakan untuk program cs, sebagai interceptor
namespace Utils
{
    public static class ServiceExtension
    {

        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<dbaplikasi_context>(options => options.UseSqlServer(configuration.GetConnectionString("dbaplikasi")));

        public static void ConfigureSqlContext2(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<dbpenampung_context>(options => options.UseSqlServer(configuration.GetConnectionString("dbpenampung")));



        public static void ConfigureCors(this IServiceCollection service) => service.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddHttpContextAccessor(); 
            services?.AddScoped<IServiceManager, ServiceManager>();
            services?.AddScoped<IRepositoriesManager, RepositoryManager>();
            services?.AddScoped<IGetResponse, ServiceGetResponse>();
        }

        public static void ConfigureSwagger(this IServiceCollection service, string appTitle = "")
        {
            service.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = appTitle, Version = "v1" });
            });
        }


    }
}
