using serviceEnterprise.Domain.ValueObjects;

namespace serviceEnterprise.Domain.Entities;

public class Sale
{
    public Guid Id { get; set; }
    public Guid CompanyIdFk { get; set; }
    public Guid ProductIdFk { get; set; }
    public Guid PeriodIdFk { get; set; }
    public Quantity Quantity { get; set; } = null!;
    public Money UnitPrice { get; set; } = null!;
    public DateTime SaleDate { get; set; }
}
