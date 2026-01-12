using Npgsql;
using serviceEnterprise.Domain.Entities;
using serviceEnterprise.Domain.Exceptions;
using serviceEnterprise.Domain.Interfaces;
using System.Data;

namespace serviceEnterprise.Infrastructure.Persistence;

public class SupplierRepository : ISupplierRepository
{
    private readonly NpgsqlConnection _connection;

    public SupplierRepository(NpgsqlConnection connection)
    {
        _connection = connection;
    }

    public async Task<Supplier?> GetSupplierAsync(Guid supplierId)
    {
        await using var command = _connection.CreateCommand();
        command.CommandText = "SELECT * FROM get_supplier_by_id(@p_supplier_id)";
        command.CommandType = CommandType.Text;
        command.Parameters.AddWithValue("@p_supplier_id", supplierId);

        if (_connection.State != ConnectionState.Open)
            await _connection.OpenAsync();
        
        await using var reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;
        
        return Supplier.Rehydrate(
            reader.GetGuid(0),
            reader.GetGuid(1),
            reader.GetString(2),
            reader.GetString(3),
            reader.GetDateTime(4)
        );
    }
}