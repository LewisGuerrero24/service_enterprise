using Microsoft.Extensions.Diagnostics.HealthChecks;
using Npgsql;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace serviceEnterprise.Infrastructure.Persistence;

public class DatabaseHealthCheck : IHealthCheck
{
    private readonly string _connectionString;

    public DatabaseHealthCheck(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<HealthCheckResult> CheckHealthAsync(
        HealthCheckContext context,
        CancellationToken cancellationToken = default)
    {
        try
        {
            await using var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync(cancellationToken);

            return HealthCheckResult.Healthy("PostgreSQL OK");
        }
        catch (Exception ex)
        {
            return HealthCheckResult.Unhealthy("PostgreSQL FAILED", ex);
        }
    }
}
