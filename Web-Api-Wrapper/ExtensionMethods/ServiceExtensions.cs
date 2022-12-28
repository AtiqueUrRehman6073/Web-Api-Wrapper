using EFDataAccess;
using EFRepository.DataRepository;
using EFUtilities;
using static System.Net.Mime.MediaTypeNames;
using System;
using EFEngine.EFResources;

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

        }
        public static void ConfigureSettings(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ConnectionStrings>(options => configuration.GetSection("ConnectionStrings").Bind(options));
        }
    }
}
