namespace serviceEnterprise.Domain.Entities;

public class Company
{
    public Guid CompanyId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
}
