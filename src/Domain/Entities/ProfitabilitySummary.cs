using serviceEnterprise.Domain.ValueObjects;

namespace serviceEnterprise.Domain.Entities;

public class ProfitabilitySummary
{
    public Guid CompanyIdFk { get; set; }
    public Guid PeriodIdFk { get; set; }
    public Money TotalRevenue { get; set; } = null!;
    public Money TotalCost { get; set; } = null!;
    public Money Margin { get; set; } = null!;
    public decimal ProfitabilityPercent { get; set; }
}
