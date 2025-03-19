using System.Configuration;
using Persistence;

namespace WebApi.Extensions
{
    public class ConfigureServices
    {
        //public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        //{
        //    services.AddPersistence(configuration);
        //    // services.AddApplication();
        //}
        public IConfiguration Configuration { get; }

        public ConfigureServices(IConfiguration configuration)
        {
            Configuration = configuration;

        }
        public void config (IServiceCollection services)
        {
            services.AddPersistence(Configuration);
        }
    }
}
