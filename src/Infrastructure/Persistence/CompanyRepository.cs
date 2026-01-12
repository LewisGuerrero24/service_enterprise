using Npgsql;
using serviceEnterprise.Domain.Entities;
using serviceEnterprise.Domain.Exceptions;
using serviceEnterprise.Domain.Interfaces;
using System.Data;
using System.Text.Json;

namespace serviceEnterprise.Infrastructure.Persistence;

public class CompanyRepository : ICompanyRepository
{
    private readonly NpgsqlConnection _connection;

    public CompanyRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    // Create
    public async Task<Company> CreateAsync(Company company)
    {
        await using var command = _connection.CreateCommand();
        command.CommandText = "SELECT create_company(@name)";
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@name", company.Name);

        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();

        var result = await command.ExecuteScalarAsync();

        if (result is null)
            throw new Exception("Database returned null");

        var json = JsonDocument.Parse(result.ToString()!);
        var root = json.RootElement;

        if (!root.GetProperty("success").GetBoolean())
        {
            var error = root.GetProperty("error").GetString();
            throw new DomainException(error ?? "Error creating company");
        }

        var data = root.GetProperty("data");

        return Company.Rehydrate(
            Guid.Parse(data.GetProperty("id").GetString()!),
            data.GetProperty("name").GetString()!,
            data.GetProperty("created_at").GetDateTime()
        );

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
            companies.Add(
                Company.Rehydrate(
                    reader.GetGuid(0),
                    reader.GetString(1),
                    reader.GetDateTime(2)
                )
            );
        }

        return companies;
    }

}