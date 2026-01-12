namespace serviceEnterprise.Application.DTOs.Supplier;

public class SupplierDto
{
    public Guid SupplierId { get; set; }
    public Guid CompanyId { get; set; }
    public string ErpSupplierCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}