using Npgsql;
using serviceEnterprise.Domain.Entities;
using serviceEnterprise.Domain.Interfaces;
using System.Data;

namespace serviceEnterprise.Infrastructure.Persistence;

public class CompanyRepository : ICompanyRepository
{
    private readonly NpgsqlConnection _connection;

    public CompanyRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    // Get ALL
    public async Task<IReadOnlyList<Company>> GetAllAsync()
    {
        var companies = new List<Company>();

        await using var command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM get_companies()";
        command.CommandType = CommandType.Text;

        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();
        
        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            var company = CreateCompanyFromReader(reader);
            companies.Add(company);
        }
        return companies;
    }

    // Mapper para company
    private static Company CreateCompanyFromReader(IDataRecord record)
    {
        // Constructor privado → usamos reflection controlada
        var company = (Company)Activator.CreateInstance(
            typeof(Company),
            nonPublic: true
        )!;

        typeof(Company).GetProperty(nameof(Company.CompanyId))!
            .SetValue(company, record.GetGuid(record.GetOrdinal("company_id")));

        typeof(Company).GetProperty(nameof(Company.Name))!
            .SetValue(company, record.GetString(record.GetOrdinal("name")));

        typeof(Company).GetProperty(nameof(Company.CreatedAt))!
            .SetValue(company, record.GetDateTime(record.GetOrdinal("created_at")));

        return company;
    }
}