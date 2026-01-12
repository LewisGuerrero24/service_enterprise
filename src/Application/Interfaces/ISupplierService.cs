using serviceEnterprise.Application.DTOs.Supplier;

namespace serviceEnterprise.Application.Interfaces;

public interface ISupplierService
{
    Task<SupplierDto> GetByIdAsync(Guid supplierId);
}