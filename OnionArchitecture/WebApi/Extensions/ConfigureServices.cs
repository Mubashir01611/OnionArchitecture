namespace WebApi.Extensions
{
    public static class ConfigureServices
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddApplication();
        }
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistence(configuration);
        }
    }
}
