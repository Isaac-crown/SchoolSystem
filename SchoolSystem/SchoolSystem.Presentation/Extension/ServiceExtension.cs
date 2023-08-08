using Microsoft.EntityFrameworkCore;
using SchoolSystem.Application.Interface;
using SchoolSystem.Application.Service.Interface;
using SchoolSystem.Infrastructure.Repository;
using SchoolSystem.Infrastructure.Services;
using System.Reflection;

namespace SchoolSystem.Presentation.Extension
{
    public static class ServiceExtension
    {

        public static void ConfigureCors(this IServiceCollection services) =>
          services.AddCors(options =>
          {
              options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
          });
        public static void ConfigurePostgreSqlContext(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("PostgreSqlConnection")));

        }
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureServiceManager(this IServiceCollection services) =>
            services.AddScoped<IServiceManager, ServiceManager>();


    }
}
