using serviceEnterprise.Domain.Exceptions;

namespace serviceEnterprise.Domain.Entities;

public class Supplier
{
    public Guid SupplierId { get; private set; }
    public Guid CompanyId { get; private set; }
    public string ErpSupplierCode { get; private set; }
    public string Name { get; private set; }
    public DateTime CreatedAt { get; private set; }


    private Supplier() { }

    private Supplier(Guid id, Guid companyId, string erpSupplierCode, string name, DateTime createdAt)
    {
        SupplierId = id;
        CompanyId = companyId;
        ErpSupplierCode = erpSupplierCode;
        Name = name;
        CreatedAt = createdAt;
    }

    public Supplier(Guid companyId, string erpSupplierCode, string name)
    {
        if (companyId == Guid.Empty)
            throw new DomainException("CompanyId is required");

        if (string.IsNullOrWhiteSpace(name))
            throw new DomainException("Name is required");

        SupplierId = Guid.NewGuid();
        CompanyId = companyId;
        ErpSupplierCode = erpSupplierCode.Trim() ?? string.Empty;
        Name = name.Trim();
    }

    // Rehydrate DB -> Domain
    public static Supplier Rehydrate(
        Guid id,
        Guid companyId,
        string erpSupplierCode,
        string name,
        DateTime createdAt
    )
    {
        return new Supplier(id, companyId, erpSupplierCode, name, createdAt);
    }
}