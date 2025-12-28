namespace serviceEnterprise.Domain.Entities;

public class Product
{
    public Guid ProductId { get; set; }
    public Guid CompanyIdFk { get; set; }
    public string? ErpProductCode { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Category { get; set; }
}
