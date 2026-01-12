using serviceEnterprise.Domain.Entities;

namespace serviceEnterprise.Domain.Interfaces;

public interface ISupplierRepository
{
    Task<Supplier?> GetSupplierAsync(Guid supplierId);
}