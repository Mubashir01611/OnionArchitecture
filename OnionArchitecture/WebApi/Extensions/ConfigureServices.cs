 using Application;
using Persistence;

namespace WebApi.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ServiceDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddApplication();
            services.AddPersistence(configuration);

            services.AddControllers();
            return services;
        }
    }
}
