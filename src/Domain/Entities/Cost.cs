using serviceEnterprise.Domain.ValueObjects;

namespace serviceEnterprise.Domain.Entities;

public class Cost
{
    public Guid CostId { get; set; }
    public Guid CompanyIdFk { get; set; }
    public Guid ProductIdFk { get; set; }
    public Guid? SupplierIdFk { get; set; }
    public Guid PeriodIdFk { get; set; }
    public Money UnitCost { get; set; } = null!;
    public DateTime CostDate { get; set; }
}
