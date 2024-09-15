using MillionRealStateCompany.Application.Interfaces;
using MillionRealStateCompany.Application.Service;
using MillionRealStateCompany.Infrastructure;
using MillionRealStateCompany.Infrastructure.Interfaces;
using MillionRealStateCompany.Infrastructure.Repositories;
using MillionRealStateCompany.Shared.Abstrations;

namespace MillionRealStateCompany.Web.Extensions
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddConfiguratorGeneral(this IServiceCollection services, IConfigurationRoot configurationRoot) =>
            services.AddSingleton<IConfigurationRoot>(configurationRoot);
        
        public static IServiceCollection AddInfrastructor(this IServiceCollection services) =>

            services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped(typeof(IOwnerRepository), typeof(OwnerRepository))
                .AddScoped(typeof(IPropertyRepository), typeof(PropertyRepository))
                .AddScoped(typeof(IPropertyImageRepository), typeof(PropertyImageRepository))
                .AddScoped(typeof(IPropertyTraceRepository), typeof(PropertyTraceRepository))
                .AddScoped(typeof(IUserRepository), typeof(UserRepository));

        public static IServiceCollection AddUnitWork(this IServiceCollection services) =>

           services
               .AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));


        public static IServiceCollection AddServices(this IServiceCollection services) =>

           services
               .AddScoped(typeof(IFileService), typeof(FileService))
               .AddScoped(typeof(IHashPasswordService), typeof(HashPasswordService))
               .AddScoped(typeof(IPropertyImageService), typeof(PropertyImageService))
               .AddScoped(typeof(IPropertyService), typeof(PropertyService))
               .AddScoped(typeof(ITokenService), typeof(TokenService))
               .AddScoped(typeof(IUserService), typeof(UserService));
    }
}
