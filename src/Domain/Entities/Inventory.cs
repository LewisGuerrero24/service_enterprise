using serviceEnterprise.Domain.ValueObjects;

namespace serviceEnterprise.Domain.Entities;

public class Inventory
{
    public Guid InventoryId { get; set; }
    public Guid CompanyIdFk { get; set; }
    public Guid ProductIdFk { get; set; }
    public Guid PeriodIdFk { get; set; }
    public Quantity StockQuantity { get; set; } = null!;
}
