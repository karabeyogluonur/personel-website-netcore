using PW.Application.Utilities;
using PW.Infrastructre.Utilities;
using PW.Persistence.Utilities;

namespace PW.Web.Mvc
{
    public static class ServiceRegistration
    {
        public static void AddBaseServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }
        public static void AddLayerServices(this IServiceCollection services)
        {
            services.AddApplicationService();
            services.AddPersistenceService();
            services.AddInfrastructreService();
            
        }
    }
}
