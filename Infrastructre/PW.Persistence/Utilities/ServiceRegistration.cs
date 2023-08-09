using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PW.Application.Interfaces.Repositories;
using PW.Application.Interfaces.Repositories.UnitOfWork;
using PW.Application.Interfaces.Services.Membership;
using PW.Persistence.Contexts;
using PW.Persistence.Repositories;
using PW.Persistence.Repositories.UnitOfWork;
using PW.Persistence.Services.Membership;

namespace PW.Persistence.Utilities
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceService(this IServiceCollection services)
        {
            #region Database Context

            services.AddDbContext<PWDbContext>(options => options.UseSqlServer(Configuration.ConnectionString));

            #endregion

            #region UnitOfWork       
            services.AddScoped<IUnitOfWork,UnitOfWork>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region Services

            services.AddTransient<IUserService, UserService>();

            #endregion
        }
    }
}
