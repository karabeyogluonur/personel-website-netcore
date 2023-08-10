using Microsoft.Extensions.DependencyInjection;

namespace PW.Application.Utilities
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            #region Automapper

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            #endregion
        }
    }
}
