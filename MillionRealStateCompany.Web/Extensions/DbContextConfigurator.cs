using Microsoft.EntityFrameworkCore;
using MillionRealStateCompany.Infrastructure.Context;

namespace MillionRealStateCompany.Web.Extensions
{
    public static class DbContextConfigurator
    {
        public static IServiceCollection AddDataBaseDefault(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<MillionRealStateCompanyContext>(options =>
               options.UseSqlServer(connectionString));
    }
}
