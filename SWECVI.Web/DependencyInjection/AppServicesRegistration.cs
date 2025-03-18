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
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ITownShipRepository, TownShipRepository>();
            services.AddScoped<ITownShipService, TownShipService>();
            services.AddScoped<IPaymentInformationRepository, PaymentInformationRepository>();
            services.AddScoped<IPaymentInformationService, PaymentInformationService>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectInformationRepository, ProjectInformationRepository>();
            services.AddScoped<IProjectInformationService, ProjectInformationService>();
            services.AddScoped<IContactInformationRepository, ContactInformationRepository>();
            services.AddScoped<IContactInformationService, ContactInformationService>();
            services.AddScoped<IBuildingRepository, BuildingRepository>();
            services.AddScoped<IBuildingService, BuildingService>();
            services.AddScoped<IFloorRepository, FloorRepository>();
            services.AddScoped<IFloorService, FloorService>();



            // for caching
            services.AddScoped<ICacheProvider, CacheProvider>();
            services.AddScoped<ICacheService, CacheService>();
        }
    }
}