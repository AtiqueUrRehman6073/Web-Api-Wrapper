using EFDataAccess;
using EFRepository.DataRepository;
using EFUtilities;
using static System.Net.Mime.MediaTypeNames;
using System;
using EFEngine.EFResources;
using EFEngine.EfWarehouse;

namespace Web_Api_Wrapper.ExtensionMethods
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.WithOrigins(configuration.GetSection("CorsSettings:AllowUrls").Value.Split(';'))
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
            services.AddScoped<IDataRepository, DataRepository>();
            services.AddScoped<IEfResources, EfResources>();
            services.AddScoped<IEmployees, Employees>();
        }
        public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            //x = configuration.GetValue<string>("ConnectionStrings");
            //x = configuration.GetConnectionString("DefaultCon");
            services.Configure<ConnectionStrings>(options => configuration.Bind(options.ConnectionString));
        }
    }
}
