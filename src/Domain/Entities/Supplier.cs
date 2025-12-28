namespace serviceEnterprise.Domain.Entities;

public class Supplier
{
    public Guid SupplierId { get; set; }
    public Guid CompanyIdFk { get; set; }
    public string? ErpSupplierCode { get; set; }
    public string Name { get; set; } = string.Empty;
}
