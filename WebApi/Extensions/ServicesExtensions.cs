using Microsoft.EntityFrameworkCore;
using Repositories.EFCore;

namespace WebApi.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) => services.AddDbContext<RepositoryContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

    }
}