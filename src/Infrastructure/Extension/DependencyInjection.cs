using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;
using serviceEnterprise.Infrastructure.Persistence;
using serviceEnterprise.Domain.Interfaces;
namespace serviceEnterprise.Infrastructure.Extensions;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("PostgresConnection")
            ?? throw new InvalidOperationException("PostgresConnection not configured");

        services.AddScoped<NpgsqlConnection>(_ =>
            new NpgsqlConnection(connectionString)
        );

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<ISupplierRepository, SupplierRepository>();

        services.AddHealthChecks()
            .AddCheck("database", new DatabaseHealthCheck(connectionString));

        return services;
    }
}
