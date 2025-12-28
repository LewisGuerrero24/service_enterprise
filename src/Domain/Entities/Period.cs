namespace serviceEnterprise.Domain.Entities;

public class Period
{
    public Guid PeriodId { get; set; }
    public Guid CompanyIdFk { get; set; }
    public int Year { get; set; }
    public int Month { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
