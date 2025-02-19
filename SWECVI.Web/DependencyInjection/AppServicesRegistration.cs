using SWECVI.ApplicationCore.Interfaces;
using SWECVI.Infrastructure.Repositories;
using SWECVI.ApplicationCore.DomainServices;
using SWECVI.Infrastructure.Services;
using SWECVI.ApplicationCore.Interfaces.Repositories;
using SWECVI.ApplicationCore.Interfaces.Services;

namespace SWECVI.Web.DependencyInjection
{
    public static class AppServicesRegistration
    {
        public static void ConfigureAppServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
           
            services.AddScoped<ISystemLogRepository, SystemLogRepository>();

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
          
            // for caching
            services.AddScoped<ICacheProvider, CacheProvider>();
            services.AddScoped<ICacheService, CacheService>();
        }
    }
}