using Ardalis.GuardClauses;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CU.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connStr = configuration["ConnectionStrings:SchoolDbContext"];
            Guard.Against.NullOrWhiteSpace(connStr, "configuration[ConnectionStrings:SchoolDbContext]");


            return services;
        }
    }
}
