 using Application;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace WebApi.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection ServiceDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
           services.AddApplication();
            services.AddPersistence(configuration);
            #region API Versioning
            // Add API Versioning to the Project
            services.AddApiVersioning(config =>
            {
                // Specify the default API Version as 1.0
                config.DefaultApiVersion = new ApiVersion(1,0);
                // If the client hasn't specified the API version in the request, use the default API version number
                config.AssumeDefaultVersionWhenUnspecified = true;
                // Advertise the API versions supported for the particular endpoint
                config.ReportApiVersions = true;
            });
            #endregion
            services.AddControllers();
            return services;
        }
    }
}
